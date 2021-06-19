using EasyDine.Domain;
using EasyDine.Domain.DTo;
using EasyDine.Domain.Entities;
using EasyDine.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyDine.Persistance
{
    public class InMemoryDBContext : IInMemoryDBContext 
    {
        #region Public Fields
            public static InMemoryDBContext inMemorytData { get; } = new InMemoryDBContext();
            public List<Restaurant> _restaurants { get; set; }
            public List<User> _users { get; set; }
            public List<BlackList> _blakList { get; set; }
            public List<Favorite> _favorite { get; set; }
            public List<City> _cities { get; set; }
            public List<Country> _countries{get; set;}
        #endregion
        #region Public Methods
            public InMemoryDBContext()
            {
                _restaurants = new List<Restaurant>()
                {
                    new Restaurant(){
                         id=1,
                         name = "A&W Canada66",
                         OpensAt ="3:30",
                         closeAt = "9:00",
                         destance = "3",
                         Rating ="3",
                         image ="01",
                         country="uk",
                         city = "london",
                    },
                    new Restaurant(){
                         id=2,
                         name = "Sassy's Family",
                         OpensAt ="9:00",
                         closeAt = "9:00",
                         destance = "2",
                         Rating ="4",
                          image ="02",
                         country="canada",
                         city = "Victoria",
                    },
                    new Restaurant(){ //Cafe Zanzibar  9:30 - 8  4
                         id=3,
                         name = "Cafe Zanzibar",
                         OpensAt ="9:30",
                         closeAt = "8:00",
                         destance = "4",
                         Rating ="2",
                          image ="03",
                         country="uk",
                         city = "london",
                    },
                    new Restaurant(){//Seahorses Cafe 10 - 7 , 5
                         id=4,
                         name = "Seahorses Cafe",
                         OpensAt ="10:00",
                         closeAt = "7:00",
                         destance = "5",
                         Rating ="4",
                          image ="04",
                         country="canada",
                         city = "Victoria",
                    },
                    new Restaurant(){ //Peninsula Pizza   9-8 , 5.4
                         id=5,
                         name = "Peninsula Pizza ",
                         OpensAt ="9:00",
                         closeAt = "8:00",
                         destance = "5",
                         Rating ="3",
                          image ="05",
                         country="canada",
                         city = "Victoria",
                    },
                    new Restaurant(){
                         id=6,
                         name = "Adriana's The Whole Enchilada",
                         OpensAt ="11:00",
                         closeAt = "7:00",
                         destance = "1",
                         Rating ="3",
                          image ="06",
                         country="canada",
                         city = "Victoria",
                    },
                    new Restaurant(){
                         id=7,
                         name = "Tonollis Deli",
                         OpensAt ="8:30",
                         closeAt = "8:30",
                         destance = "3",
                         Rating ="5",
                          image ="07",
                         country="canada",
                         city = "Victoria",
                    },
                    new Restaurant(){
                         id=8,
                         name = "RNR Diner",
                         OpensAt ="8:30",
                         closeAt = "7:00",
                         destance = "5",
                         Rating ="5",
                          image ="08",
                         country="usa",
                         city = "New York",
                    },
                    new Restaurant(){
                         id=9,
                         name = "Spitfire Grill ",
                         OpensAt ="8:00",
                         closeAt = "8:00",
                         destance = "13",
                         Rating ="1",
                          image ="09",
                         country="usa",
                         city = "New York",
                    },
                    new Restaurant(){
                         id=10,
                         name = "Keating Pizza",
                         OpensAt ="11:00",
                         closeAt = "9:00",
                         destance = "1",
                         Rating ="1",
                          image ="10",
                         country="usa",
                         city = "New York",
                    }
                };
                _users = new List<User>()
                {
                    new User()
                    {
                        id=1,
                        name="David Ameny",
                        userName ="DAmeny",
                        password ="Pwd111"
                    },
                    new User()
                    {
                        id=2,
                        name="Vignesh Vasudevan",
                        userName ="VVasudevan",
                        password ="Pwd222"
                    },
                    new User()
                    {
                        id=3,
                        name="hammad Hammad",
                        userName ="MHammad",
                        password ="Pwd333"
                    }
                };
                _blakList = new List<BlackList>()
                {
                    new BlackList()
                    {
                        id=1,
                        restaurantId = 2,
                        userId = 3,
                        isBlakListed =true
                    },
                    new BlackList()
                    {
                        id=2,
                        restaurantId = 5,
                        userId = 3,
                        isBlakListed =true
                    },
                    new BlackList()
                    {
                        id=1,
                        restaurantId = 8,
                        userId = 1,
                        isBlakListed =true
                    },
                };
                _favorite = new List<Favorite>() {
                    new Favorite()
                    {
                        id=1,
                        restaurantId = 8,
                        userId = 2,
                        isFavorite = true
                    },
                    new Favorite()
                    {
                        id=2,
                        restaurantId = 6,
                        userId = 2,
                        isFavorite = true
                    },
                    new Favorite()
                    {
                        id=3,
                        restaurantId = 4,
                        userId = 2,
                        isFavorite = true
                    },
                    new Favorite()
                    {
                        id=4,
                        restaurantId = 1,
                        userId = 1,
                        isFavorite = true
                    },
                    new Favorite()
                    {
                        id=5,
                        restaurantId = 3,
                        userId = 1,
                        isFavorite = true
                    },
                    new Favorite()
                    {
                        id=6,
                        restaurantId = 5,
                        userId = 3,
                        isFavorite = true
                    },
                    new Favorite()
                    {
                        id=7,
                        restaurantId = 9,
                        userId = 3,
                        isFavorite = true
                    },
                };
                _countries = new List<Country>()
                {
                    new Country()
                    {
                        id="1",
                        name="canada"
                    },
                    new Country()
                    {
                        id="2",
                        name="usa"
                    },
                    new Country()
                    {
                        id="3",
                        name="uk"
                    }
                };
                _cities = new List<City>()
                {
                    new City()
                    {
                        id="1",
                        name="london"
                    },
                    new City()
                    {
                        id="2",
                        name="Victoria"
                    },
                    new City()
                    {
                        id="3",
                        name="New York"
                    }
                };
            }
            public IEnumerable<RestaurantViewModel> SearchFoRestaurants(SearchViewModel criteria)
            {
                var Query = from rest in _restaurants
                            let BackListed =
                                (from b in _blakList
                                 where b.restaurantId == rest.id && b.userId == criteria.user_ID
                                 select b.isBlakListed)
                            let Favorite =
                                (from f in _favorite
                                 where f.restaurantId == rest.id && f.userId == criteria.user_ID
                                 select f.isFavorite)
                            orderby rest.id
                            select new RestaurantViewModel
                            {
                                id = rest.id,
                                name = rest.name,
                                image = rest.image,
                                destance = rest.destance,
                                Rating = rest.Rating,
                                country = rest.country,
                                //blackLists = __blacklist,
                                city = rest.city,
                                isBlakListed = BackListed.FirstOrDefault() ? true : false,
                                isFavorite = Favorite.FirstOrDefault() ? true : false,
                            };
                try
                {
                    if (Query != null)
                    {
                        Query = (from r in Query.Where(r => !r.isBlakListed)
                                 select r).ToList();
                        if (criteria.favorites)
                        {
                            Query = (from r in Query.Where(r => r.isFavorite == criteria.favorites)
                                     select r).ToList();
                        }
                        if (!string.IsNullOrEmpty(criteria.cityID))
                        {
                            var _country = GetCityByID(criteria.cityID);
                            Query = (from r in Query.Where(r => string.Equals(r.city, _country, StringComparison.OrdinalIgnoreCase)) select r).ToList();
                        }
                        if (!string.IsNullOrEmpty(criteria.countryID))
                        {
                            var _country = GetCountryByID(criteria.countryID);
                            Query = (from r in Query.Where(r => string.Equals(r.country, _country, StringComparison.OrdinalIgnoreCase))
                                     select r).ToList();
                        }
                        if (!string.IsNullOrEmpty(criteria.RestaurantName))
                        {
                            Query = (from r in Query.Where(r => r.name.Trim().Contains(criteria.RestaurantName.Trim(), StringComparison.OrdinalIgnoreCase))
                                     select r).ToList();
                        }
                        if (!string.IsNullOrEmpty(criteria.Rating))
                        {
                            Query = (from r in Query.Where(r => r.Rating == criteria.Rating)
                                     select r).ToList();
                        }
                        if (!string.IsNullOrEmpty(criteria.distance))
                        {
                            Query = (from r in Query.Where(r => r.destance == criteria.distance)
                                     select r).ToList();
                        }
                        if (!string.IsNullOrEmpty(criteria.postalCode))
                        {
                            Query = (from r in Query.Where(r => int.Parse(r.postalCode) == int.Parse(criteria.postalCode))
                                     select r).ToList();
                        }

                    if (Query!=null && Query.Count() > 0)
                    {
                        List<BlackList> queryBlacklist = (from r in _blakList.Where(b => b.userId == criteria.user_ID && b.isBlakListed == true)
                                                          select r).ToList();
                        if (queryBlacklist != null)
                        {
                            Query.FirstOrDefault().blackLists = queryBlacklist;
                        }
                    }
                       return Query;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return Query;
            }
            //public List<BlackList> GetBlackListsedItemForUser(int userId)
            //{
            //List<BlackList> query = (from r in _blakList.Where(b => b.userId == userId && b.isBlakListed == true)
            //                 select r).ToList();
            //return query == null ? new List<BlackList>() : query;
            //}
            public List<RestaurantViewModel> GetListOfRestaurants()
            {
                var query = from restaurant in _restaurants
                            select new RestaurantViewModel
                            {
                                id = restaurant.id,
                                name = restaurant.name,
                                image = restaurant.image,
                                destance = restaurant.destance,
                                Rating = restaurant.Rating,
                                isBlakListed = false,
                                isFavorite = false,
                                //blackLists = __blacklist,
                            };
                return (List<RestaurantViewModel>)query.ToList();
            }
            private string GetCountryByID(string id)
            {
                return _countries.Where(r => r.id == id).FirstOrDefault().name;
            }
            private string GetCityByID(string id)
            {
                return _cities.Where(r => r.id == id).FirstOrDefault().name;
            }
            bool IInMemoryDBContext.ToogleFavoriteRestaurantForUser(int userId, string restaurantId)
            {
                var favorite = _favorite.FirstOrDefault(f => f.userId == userId && f.restaurantId == int.Parse(restaurantId));
                if (favorite == null)
                {

                    _favorite.Add(new Favorite { userId = userId, restaurantId = int.Parse(restaurantId), isFavorite = true });
                }
                else
                {
                    _favorite.FirstOrDefault(f => f.userId == userId && f.restaurantId == int.Parse(restaurantId)).isFavorite = !_favorite.FirstOrDefault(f => f.userId == userId && f.restaurantId == int.Parse(restaurantId)).isFavorite;
                }
                return true;
            }
            bool IInMemoryDBContext.ToogleBlacklistRestaurantForUser(int userId, string restaurantId)
            {
                try
                {
                    var blacklist = _blakList.FirstOrDefault(b => b.userId == userId && b.restaurantId == int.Parse(restaurantId));
                    if (blacklist == null)
                    {
                        _blakList.Add(new BlackList { userId = userId, restaurantId = int.Parse(restaurantId), isBlakListed = true });
                    }
                    else
                    {
                        _blakList.FirstOrDefault(b => b.userId == userId && b.restaurantId == int.Parse(restaurantId)).isBlakListed = !_blakList.FirstOrDefault(b => b.userId == userId && b.restaurantId == int.Parse(restaurantId)).isBlakListed;
                    }
                    //.isBlakListed = setBlacklist;
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        List<RestaurantViewModel> IInMemoryDBContext.GetBlacklested(int user_ID)
        {
            var Query = from rest in _restaurants
                        join blklist in _blakList
                        on rest.id equals blklist.restaurantId
                        where (blklist.userId == user_ID)
                        orderby rest.name
                        select new RestaurantViewModel
                        {
                            id = rest.id,
                            name = rest.name,
                            image = rest.image,
                            destance = rest.destance,
                            Rating = rest.Rating,
                            country = rest.country,
                            city = rest.city,
                            isBlakListed = blklist.isBlakListed,
                        };
            return (List<RestaurantViewModel>)Query.ToList();
        }
        public void dispose()
        {

        }

        bool IInMemoryDBContext.clearlist(int user_ID)
        {
            var list = _blakList.Where(r => r.userId == user_ID);
            List< BlackList> newlist = new List<BlackList>();
            foreach (var item in list)
            {
                item.isBlakListed = false;
                newlist.Add(item);
            }
            _blakList.Clear();
            _blakList = newlist;
            return true;
        }
        #endregion
    }
}
