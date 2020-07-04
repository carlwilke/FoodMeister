using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMeister.Core;
using FoodMeister.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodMeister.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Core.Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData,
                        IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Core.Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                // The restaurant have a valid ID so update
                _restaurantData.Update(Restaurant);
            }
            else
            {
                // The restaurant does not have an ID assigned so add to the data
                _restaurantData.Add(Restaurant);
            }

            _restaurantData.Commit();
            TempData["Message"] = "Restaurant Data Saved";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });

        }
    }
}