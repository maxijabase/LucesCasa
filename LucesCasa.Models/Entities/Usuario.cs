using System;
using System.Collections.Generic;

#nullable disable

namespace LucesCasa.Models.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
