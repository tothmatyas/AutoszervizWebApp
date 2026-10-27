using System.ComponentModel.DataAnnotations;

namespace AutoszervizWebApp.Models
{
    public class Javitas
    {
        public int Id { get; set; }
        public int UgyfelId { get; set; }
        [Required]
        [StringLength(10)]
        public string Rendszam { get; set; }
        [StringLength(300)]
        public string Leiras { get; set; }
        public decimal Koltseg { get; set; }
        public string Allapot { get; set; }
        public DateTime FelvetelDatuma { get; set; }

        //navigacios tulajdonsag

        public Ugyfel Ugyfel { get; set; }

    }
}
