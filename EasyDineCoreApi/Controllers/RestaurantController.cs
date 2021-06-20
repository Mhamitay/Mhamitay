using EasyDine.Application;
using EasyDine.Domain;
using EasyDine.Domain.DTo;
using Microsoft.AspNetCore.Mvc;
using System;
namespace EasyDineCoreApi.Controllers
{
/// <summary>
/// Restaurant API End point
/// </summary>
[Route("api/[controller]")]
[ApiController]
 public class RestaurantsController : ControllerBase
{
    public IDataRepository _DataRepository { get; }
    public RestaurantsController(IDataRepository dataRepository)
    {
        _DataRepository = dataRepository;
    }

        /// <summary>
        /// Get list of restaurants 
        /// </summary>
        /// <returns> list of restaurants  </returns>
        [HttpGet]
    public IActionResult Get()
    {
        if (ModelState.IsValid)
            {
                try
                {
                    var restaurant = _DataRepository.GetListOfRestaurants();

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
        ///     Search for restaurant base on the SearchViewMode
        /// </summary>
        /// <param name="searchViewModel"></param>
        /// <returns></returns>
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
    }
}
