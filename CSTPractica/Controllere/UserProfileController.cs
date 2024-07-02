using Microsoft.AspNetCore.Mvc;

namespace CalotescuPractica.DataLayer.CSTPractica.Controllere
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserProfileController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetMyProfile")]
        public IActionResult GetMyProfile(int userId)
        {
            // Add logic to get user profile
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        [HttpPost("UpdateUserProfile")]
        public IActionResult UpdateUserProfile([FromBody] User user)
        {
            // Add logic to update user profile
            var existingUser = _userRepository.GetById(user.UserId);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            // Update other fields as necessary

            _userRepository.Update(existingUser);
            _userRepository.Save();
            return Ok("User profile updated successfully.");
        }

        [HttpPost("AddUserAddress")]
        public IActionResult AddUserAddress(int userId, [FromBody] Address address)
        {
            // Add logic to add user address
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.Addresses.Add(address);
            _userRepository.Update(user);
            _userRepository.Save();
            return Ok("Address added successfully.");
        }
    }

}
