﻿using Fundamentals.Core;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurat);
        int Commit();
    }

    public class InMemotyRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemotyRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Meryland", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Tico Tacos", Location = "Los Angeles", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Vindalou", Location = "Riverside", Cuisine = CuisineType.Indian },
            };
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant!= null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;

        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                   orderby r.Name
                   select  r;
        }
    }
}
