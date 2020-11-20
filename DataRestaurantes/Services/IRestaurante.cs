using EdgarAparicio.Restaurantes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarAparicio.Restaurantes.Data.Services
{
    public interface IRestaurante
    {
        IEnumerable<Restaurante> ObtenerListaRestaurantes();

        Restaurante ObtenerRestaurantePorId(int idRestaurante);

        Restaurante CrearRestaurante(Restaurante restauranteNuevo);

        Restaurante EditarRestaurante(Restaurante restauranteEditado);

        Restaurante EliminarRestaurante(int idRestaurante);


    }
}
