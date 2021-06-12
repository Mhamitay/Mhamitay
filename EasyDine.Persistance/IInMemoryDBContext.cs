using EasyDine.Domain;
using EasyDine.Domain.DTo;
using EasyDine.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EasyDine.Persistance.Repositories
{
    public interface IInMemoryDBContext
    {
        List<BlackList> _blakList { get; set; }
        List<Favorite> _favorite { get; set; }
        List<Restaurant> _restaurants { get; set; }
        List<User> _users { get; set; }
        List<City> _cities { get; set; }
        List<Country> _countries { get; set; }
        List<RestaurantViewModel> GetListOfRestaurants();
        IEnumerable<RestaurantViewModel> SearchFoRestaurants(SearchViewModel searchcriteria);
        //List<BlackList> GetBlackListsedItemForUser(int userId);
        bool ToogleFavoriteRestaurantForUser(int userID, string restaurantId);
        bool ToogleBlacklistRestaurantForUser(int userID, string restaurantId);
        void dispose();
        List<RestaurantViewModel> GetBlacklested(int user_ID);
        bool clearlist(int user_ID);
    }
}