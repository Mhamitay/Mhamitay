using EasyDine.Application;
using EasyDine.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDineCoreApi.Controllers
{
    /// <summary>
    /// Favorites API End point
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        public IDataRepository _DataRepository { get; private set; }

        public FavoriteController(IDataRepository dataRepository)
        {
            _DataRepository = dataRepository;
        }
        /// <summary>
        ///    Toogle (Un/Favorites) a Restaurants for specific user
        /// </summary>
        /// <param name="searchViewModel"></param>
        /// <returns>it dose not return anything</returns>
        [HttpPost("Favorite")]
        public IActionResult Favorite(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var restaurant = _DataRepository.ToggleFavorite(searchViewModel.user_ID, searchViewModel.restaurantid);
                    if (restaurant)
                    {
                        var _restaurant = _DataRepository.SearchFoRestaurants(searchViewModel);

                        return _restaurant.Count == 0 || _restaurant == null ? NoContent() : (IActionResult)Ok(_restaurant);
                    }
                    return !restaurant ? BadRequest("was not able to set favorite") : (IActionResult)Ok(restaurant);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return Ok("Bad request please try again ");
        }

        
    }
}
