using EdgarAparicio.Restaurantes.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarAparicio.Restaurantes.Data.Services
{
    public class DbContextRestaurantes : DbContext
    {
        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}
