using EasyDine.Application;
using EasyDine.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDineCoreApi.Controllers
{  /// <summary>
   /// BlackList API End point
   /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlackListController : ControllerBase
    {
        public IDataRepository _DataRepository { get; private set; }
        public BlackListController(IDataRepository dataRepository)
        {
            _DataRepository = dataRepository;
        }

        // GET: api/<BlackListController>
        [HttpGet]
        public IActionResult Get(SearchViewModel searchViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var restaurant = _DataRepository.GetBlacklested(searchViewModel.user_ID);

                    return restaurant.Count == 0 || restaurant == null ? NoContent() : (IActionResult)Ok(restaurant);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return Ok("Bad request please try again ");
        }

        /// <summary>
        ///    Un Blacklist all restaurants
        /// </summary>
        /// <param name="searchViewModel"></param>
        /// <returns>it dose not return anything</returns>
        [HttpPost("Delete")]
        public IActionResult Delete(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var restaurant = _DataRepository.clearlist(searchViewModel.user_ID);
                    if (restaurant)
                    {
                        var _restaurant = _DataRepository.SearchFoRestaurants(searchViewModel);

                        return _restaurant.Count == 0 || _restaurant == null ? NoContent() : (IActionResult)Ok(_restaurant);
                    }
                    return !restaurant ? BadRequest("was not able to remove all black list") : (IActionResult)Ok(restaurant);

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return Ok("Bad request please try again ");
        }
        /// <summary>
        ///    Blacklist a Restaurant
        /// </summary>
        /// <param name="searchViewModel"></param>
        /// <returns>it dose not return anything</returns>
        [HttpPost("Blacklist")]
        public IActionResult Blacklist(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var restaurant = _DataRepository.ToggleBlackList(searchViewModel.user_ID, searchViewModel.restaurantid);
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
