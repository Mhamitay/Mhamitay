using EasyDine.Application;
using EasyDine.Domain;
using EasyDine.Domain.DTo;
using Microsoft.AspNetCore.Mvc;
using System;
namespace EasyDineCoreApi.Controllers
{
[Route("api/[controller]")]
[ApiController]
 public class RestaurantsController : ControllerBase
{
    public IDataRepository _DataRepository { get; }
    public RestaurantsController(IDataRepository dataRepository)
    {
        _DataRepository = dataRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var restaurant = _DataRepository.GetListOfRestaurants();
            return restaurant.Count == 0 ? NotFound() : (IActionResult)Ok(restaurant);
        }
        catch (Exception)
        {
           return BadRequest();
        }
    }
  
   [HttpPost("Search")]
    public IActionResult Search(SearchViewModel searchViewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var restaurant = _DataRepository.SearchFoRestaurants(searchViewModel);

                return restaurant.Count == 0 || restaurant == null ? NoContent() : (IActionResult)Ok(restaurant);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        return Ok("Bad request please try again ");
    }

        [HttpPost("Getblacklisted")]
        public IActionResult Getblacklisted(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
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



        [HttpPost("favorite")]
    public IActionResult favorite(SearchViewModel searchViewModel)
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
    [HttpPost("blacklist")]
    public IActionResult blacklist(SearchViewModel searchViewModel)
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


        [HttpPost("clearlist")]
        public IActionResult clearlist(SearchViewModel searchViewModel)
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
