using LucesCasa.Common;
using LucesCasa.Models.DTO;
using LucesCasa.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace LucesCasa.Backend
{
    public class BELuces
    {
        private readonly LucesCasaContext _context;
        private readonly HttpClient _httpClient;
        public BELuces(LucesCasaContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }
        public async Task<InstruccionDTO> EnviarInstruccion(InstruccionDTO ins)
        {
            // Obtener luz que corresponde al ID
            var luz = await _context.Luces.SingleAsync(x => x.Id == ins.ID);

            // Enviar HTTP POST al módulo con la instrucción

            var instruccion = new InstruccionModuloDTO
            {
                User = ServiceConfiguration.ModuleUser,
                Password = ServiceConfiguration.ModulePassword,
                Pin = luz.Pin,
                Estado = luz.Estado
            };

            var response = await _httpClient.PostAsync("http://" + luz.Ip + "/body",
                new StringContent(JsonSerializer.Serialize(instruccion), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            return ins;
        }
    }
}