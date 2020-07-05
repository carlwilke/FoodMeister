using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMeister.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodMeister.ViewComponents
{
    public class RestaurantCountViewComponent
        : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
