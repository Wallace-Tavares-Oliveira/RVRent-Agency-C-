using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RVRentAgencia.Models
{
    public class Destino
    {
        [Key]
        [Required]
        public int Id_Destino { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public DateTime Partida { get; set; }
        [Required]
        public DateTime Retorno { get; set; }
    }
}