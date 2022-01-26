using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace LucesCasa.Models.DTO
{
    public class InstruccionModuloDTO
    {
        public string User { get; set; }
        public string Password { get; set; }
        public int Pin { get; set; }
        public int Estado { get; set; }
    }
}
