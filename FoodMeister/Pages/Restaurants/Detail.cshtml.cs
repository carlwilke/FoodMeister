using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMeister.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMeister.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Core.Restaurants Restaurants { get; set; }


        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurants = restaurantData.GetById(restaurantId);
            if (Restaurants == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}