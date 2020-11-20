using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarAparicio.Restaurantes.Data.Models
{
    public class Restaurante
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Required, StringLength(250)]
        public string Descripcion { get; set; }

        public TipoRestaurante TipoRestaurante { get; set; }

    }
}
