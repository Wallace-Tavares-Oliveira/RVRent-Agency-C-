using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RVRentAgencia.Models
{
    public class Promocao
    {
        [Key]
        [Required]
        public int Id_Promocao { get; set; }
        [Required]
        public string Preco { get; set; }
    }
}