using IdentityProviderApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Base;
using Service.Model;

namespace IdentityProviderApi.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        IUserService _userService;

        public AuthController(IUserService userService) {
            _userService = userService;
        }

        [Route("users")]
        [HttpGet]
        [Authorize(Roles = "Admin, Agent")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = _userService.Authenticate(login);

            if (user != null)
            {
                string tokenString = TokenUtil.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}
