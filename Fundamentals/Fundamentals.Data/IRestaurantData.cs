using Fundamentals.Core;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

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
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select  r;
        }
    }
}
