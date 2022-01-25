using LucesCasa.Backend;
using LucesCasa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LucesCasa.Api.Controllers
{
    public class LucesController : Controller
    {
        private readonly BELuces _lucesHelper;
        public LucesController(BELuces lucesHelper)
        {
            _lucesHelper = lucesHelper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EnviarInstruccion(InstruccionDTO ins)
        {
            _lucesHelper.ToString();
        }
    }
}
