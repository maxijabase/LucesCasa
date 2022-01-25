using LucesCasa.Backend;
using LucesCasa.Models;
using Microsoft.AspNetCore.Mvc;

namespace LucesCasa.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly BEAuth _authHelper;

        public AuthController(BEAuth authHelper)
        {
            _authHelper = authHelper;
        }

        [HttpPost, Route("login")]
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
