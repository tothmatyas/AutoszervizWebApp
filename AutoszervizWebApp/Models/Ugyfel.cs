using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoszervizWebApp.Models
{
    public class Ugyfel
    {

        public int Id { get; set; }

        
        [StringLength(100)]
        [Required]
        public string Nev { get; set; }
        
        [StringLength(20)]
        public string Telefon { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //navigacios tulajdonsag
        
        public List<Javitas> Javitasok { get; set; } = new();

    }
}
