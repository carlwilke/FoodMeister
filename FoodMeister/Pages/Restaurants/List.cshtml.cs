using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using FoodMeister.Data;

namespace FoodMeister.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData _restaurantData;

        public IEnumerable<Core.Restaurants> Restaurantes { get; set; }
        public ListModel(IConfiguration config,
                        IRestaurantData restaurantData)
        {
            this.config = config;
            _restaurantData = restaurantData;
        }
        public void OnGet(string searchTerm)
        {
            Restaurantes = _restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}
