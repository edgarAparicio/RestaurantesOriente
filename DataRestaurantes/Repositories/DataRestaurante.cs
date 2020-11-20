using EdgarAparicio.Restaurantes.Data.Models;
using EdgarAparicio.Restaurantes.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarAparicio.Restaurantes.Data.Repositories
{
    public class DataRestaurante : IRestaurante
    {
        private readonly DbContextRestaurantes db;

        public DataRestaurante(DbContextRestaurantes dbContextRestaurantes)
        {
            this.db = dbContextRestaurantes;
        }

        public Restaurante CrearRestaurante(Restaurante restaurante)
        {
            var restauranteNuevo = db.Restaurantes.Add(restaurante);
            db.SaveChanges();
            return restauranteNuevo;
        }

        public Restaurante EditarRestaurante(Restaurante restauranteEditado)
        {
            var restaurante = db.Restaurantes.Attach(restauranteEditado);
            db.Entry(restaurante).State = EntityState.Modified;
            db.SaveChanges();
            return restaurante;
        }

        public Restaurante EliminarRestaurante(int idRestaurante)
        {

            var restauranteEliminado = ObtenerRestaurantePorId(idRestaurante);
            if(restauranteEliminado != null)
            {
                db.Restaurantes.Remove(restauranteEliminado);
                db.SaveChanges();
            }
            return restauranteEliminado;
        }

        public IEnumerable<Restaurante> ObtenerListaRestaurantes()
        {
            IEnumerable<Restaurante> listaRestaurantes =
                from entidadRestaurantes in db.Restaurantes
                select entidadRestaurantes;

            return listaRestaurantes;
        }

        public Restaurante ObtenerRestaurantePorId(int idRestaurante)
        {
            var restaurante = db.Restaurantes.Find(idRestaurante);
            return restaurante;
        }

        


        
    }
}
