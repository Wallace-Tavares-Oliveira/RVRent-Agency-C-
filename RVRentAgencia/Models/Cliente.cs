using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RVRentAgencia.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id_Cliente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }

        // FOREING KEYS
        [Required]
        public int DestinoId_destino { get; set; }
        public Destino Destino { get; set; }
        [Required]
        public int PromocaoId_promocao { get; set; }
        public Promocao Promocao { get; set; }
        [Required]
        public int ContatoId_contato { get; set; }
        public Contato Contato { get; set; }
    }
}