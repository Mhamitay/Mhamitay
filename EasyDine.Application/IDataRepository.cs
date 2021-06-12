using EasyDine.Domain;
using EasyDine.Domain.DTo;
using System;
using System.Collections.Generic;

namespace EasyDine.Application
{
    public interface IDataRepository :IDisposable
    {
        List<RestaurantViewModel> GetListOfRestaurants();
        List<RestaurantViewModel> SearchFoRestaurants(SearchViewModel userId);
        Restaurant GetRestaurantById(int id);
        bool ToggleBlackList(int restaurantId, string userID);
        void AddRestaurant(Restaurant restaurant);
        bool ToggleFavorite(int userID, string restaurantId);
        List<RestaurantViewModel> GetBlacklested(int user_ID);
        bool clearlist(int user_ID);
    }
}