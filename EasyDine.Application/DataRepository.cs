using EasyDine.Domain;
using EasyDine.Domain.DTo;
using EasyDine.Persistance.Repositories;
using System;
using System.Collections.Generic;
namespace EasyDine.Application
{
    public class DataRepository : IDataRepository  
    {
        #region Public Props
            public IInMemoryDBContext _InMemoryDBContext { get; }
        #endregion
        #region public Methods
            public DataRepository(IInMemoryDBContext inMemoryDBContext)
            {
                _InMemoryDBContext = inMemoryDBContext;
            }
            List<RestaurantViewModel> IDataRepository.GetListOfRestaurants()
            {
                var Query = _InMemoryDBContext.GetListOfRestaurants();
                return (List<RestaurantViewModel>)Query;
            }
            List<RestaurantViewModel> IDataRepository.SearchFoRestaurants(SearchViewModel searchcriteria)
            {
                var Query = _InMemoryDBContext.SearchFoRestaurants(searchcriteria);
                return Query == null ? new List<RestaurantViewModel>() : (List<RestaurantViewModel>)Query;
            }
            void addRestaurant(Restaurant restaurant)
            {
                _InMemoryDBContext._restaurants.Add(restaurant);
            }
            bool IDataRepository.ToggleFavorite(int userID, string restaurantId)
            {
                return _InMemoryDBContext.ToogleFavoriteRestaurantForUser(userID, restaurantId); ;
            }
            bool IDataRepository.ToggleBlackList(int userID, string restaurantId)
            {
                return _InMemoryDBContext.ToogleBlacklistRestaurantForUser(userID, restaurantId);
            }
            void IDataRepository.AddRestaurant(Restaurant restaurant)
            {
                _InMemoryDBContext._restaurants.Add(restaurant);
            }
            Restaurant IDataRepository.GetRestaurantById(int id)
            {
                throw new NotImplementedException();
            }
            List<RestaurantViewModel> IDataRepository.GetBlacklested(int user_ID)
            {
                return _InMemoryDBContext.GetBlacklested(user_ID);
            }
            public void Dispose()
            {

            }

        bool IDataRepository.clearlist(int user_ID)
        {
            return _InMemoryDBContext.clearlist(user_ID);
        }
        #endregion
    }
}
