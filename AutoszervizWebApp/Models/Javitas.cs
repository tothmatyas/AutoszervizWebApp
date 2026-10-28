using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoszervizWebApp.Models
{
    public class Javitas
    {
        public int Id { get; set; }
        public int UgyfelId { get; set; }
        
        [StringLength(10, ErrorMessage = "A rendszám maximum 10 karakter hosszú lehet.")]
        [Required]
        public string Rendszam { get; set; }
        [StringLength(300, ErrorMessage = "A leírás maximum 300 karakter hosszú lehet.")]
        public string Leiras { get; set; }
        public decimal Koltseg { get; set; }
        public string Allapot { get; set; }
        public DateTime FelvetelDatuma { get; set; }

        //navigacios tulajdonsag
        [ForeignKey(nameof(UgyfelId))]
        public Ugyfel? Ugyfel { get; set; }
    }
}
