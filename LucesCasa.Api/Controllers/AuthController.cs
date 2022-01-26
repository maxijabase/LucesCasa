using LucesCasa.Backend;
using LucesCasa.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LucesCasa.Api.Controllers
{
    [Route("login")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly BEAuth _authHelper;

        public AuthController(BEAuth authHelper)
        {
            _authHelper = authHelper;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO model)
        {
            if (model == null)
            {
                return BadRequest("Invalid login request");
            }
            var token = _authHelper.Authorize(model);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
    }
}
