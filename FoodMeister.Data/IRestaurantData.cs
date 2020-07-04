using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodMeister.Core;

namespace FoodMeister.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetRestaurantsByName(string name);
        Restaurants GetById(int id);
        Restaurants Update(Restaurants updatedRestaurants);
        Restaurants Add(Restaurants newRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurants> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurants>()
            {
                new Restaurants { Id = 1, Name = "Papa Carlos", Location = "Helsingborg", Cuisine = CuisineType.Italian },
                new Restaurants { Id = 2, Name = "Lucas Curry", Location = "Heraklion", Cuisine = CuisineType.Indian },
                new Restaurants { Id = 3, Name = "Slobbans Greasy Spoon", Location = "Crawley", Cuisine = CuisineType.None },
                new Restaurants { Id = 4, Name = "Binge Drinkers", Location = "Manchester", Cuisine = CuisineType.Pub },
                new Restaurants { Id = 5, Name = "Pedros Fiesta", Location = "Alcapulco", Cuisine = CuisineType.Mexican }
            };
        }

        public IEnumerable<Restaurants> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurants GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurants Add(Restaurants newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }


        // Used for local testing before connecting to database
        public Restaurants Update(Restaurants updatedRestaurants)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurants.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurants.Name;
                restaurant.Location = updatedRestaurants.Location;
                restaurant.Cuisine = updatedRestaurants.Cuisine;
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
