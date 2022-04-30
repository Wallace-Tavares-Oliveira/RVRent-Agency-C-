using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RVRentAgencia.Models;

namespace RVRentAgencia.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> opt) : base(opt)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
    }
}