using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RVRentAgencia.Models
{
    public class Contato
    {
        [Key]
        [Required]
        public int Id_Contato { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mensagem { get; set; }
    }
}