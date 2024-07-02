using Microsoft.AspNetCore.Mvc;

namespace CalotescuPractica.DataLayer.CSTPractica.Controllere
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public AccountController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User user)
        {
            // Add user registration logic here
            _userRepository.Insert(user);
            _userRepository.Save();
            return Ok("User registered successfully.");
        }

        [HttpPost("Login")]
        public IActionResult Login(string username, string password)
        {
            // Add login logic here
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("User logged in successfully.");
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(int userId, string newPassword)
        {
            // Add change password logic here
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.Password = newPassword;
            _userRepository.Update(user);
            _userRepository.Save();
            return Ok("Password changed successfully.");
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            // Simulate forgot password logic here
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return NotFound("Email not found.");
            }

            Console.WriteLine($"Password reset link sent to {email}");
            return Ok("Password reset link sent.");
        }
    }

}
