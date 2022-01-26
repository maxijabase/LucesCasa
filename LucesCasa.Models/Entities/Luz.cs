using System;
using System.Collections.Generic;

#nullable disable

namespace LucesCasa.Models.Entities
{
    public partial class Luz
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Ip { get; set; }
        public int Pin { get; set; }
        public int Estado { get; set; }
    }
}
