using System;
using System.Collections.Generic;

#nullable disable

namespace LucesCasa.Models.Entities
{
    public partial class Log
    {
        public string IdLog { get; set; }
        public int? Timestamp { get; set; }
        public string Responsable { get; set; }
        public string Descripcion { get; set; }
    }
}
