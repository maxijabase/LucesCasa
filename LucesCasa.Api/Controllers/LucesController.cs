using LucesCasa.Backend;
using LucesCasa.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LucesCasa.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LucesController : Controller
    {
        private readonly BELuces _lucesHelper;
        public LucesController(BELuces lucesHelper)
        {
            _lucesHelper = lucesHelper;
        }

        [HttpPost]
        public async Task<IActionResult> EnviarInstruccion(InstruccionDTO ins)
        {
            await _lucesHelper.EnviarInstruccion(ins);
            return Ok();
        }
    }
}
