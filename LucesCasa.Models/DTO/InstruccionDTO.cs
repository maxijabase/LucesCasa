using System.ComponentModel.DataAnnotations;

namespace LucesCasa.Models.DTO
{
    public class InstruccionDTO
    {
        [Required]
        public int? ID { get; set; }
        [Required]
        public int? Estado { get; set; }
    }
}