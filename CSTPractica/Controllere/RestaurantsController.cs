using Microsoft.AspNetCore.Mvc;

namespace CalotescuPractica.DataLayer.CSTPractica.Controllere
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRepository<Restaurant> _restaurantRepository;

        public RestaurantsController(IRepository<Restaurant> restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var restaurants = _restaurantRepository.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}/Menu")]
        public IActionResult GetMenu(int id)
        {
            var restaurant = _restaurantRepository.GetById(id);
            if (restaurant == null)
            {
                return NotFound("Restaurant not found.");
            }

            return Ok(restaurant.MenuItems);
        }
    }

}
