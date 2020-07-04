using System.Collections.Generic;
using System.Linq;
using FoodMeister.Core;

namespace FoodMeister.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Papa Carlos", Location = "Helsingborg", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Lucas Curry", Location = "Heraklion", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Slobbans Greasy Spoon", Location = "Crawley", Cuisine = CuisineType.None },
                new Restaurant { Id = 4, Name = "Binge Drinkers", Location = "Manchester", Cuisine = CuisineType.Pub },
                new Restaurant { Id = 5, Name = "Pedros Fiesta", Location = "Alcapulco", Cuisine = CuisineType.Mexican }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Name
                select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }


        // Used for local testing before connecting to database
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            // Placeholder for the database commit
            return 0;
        }
    }
}