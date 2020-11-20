using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EdgarAparicio.Restaurantes.Data.Repositories;
using EdgarAparicio.Restaurantes.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestaurantesOriente.App_Start
{
    public class ConfiguracionContenedor
    {
        internal static void RegistrarContenedor(HttpConfiguration httpConfiguration) //parametro que recibe es configuracion para la api
        {
            var constructor = new ContainerBuilder();
            constructor.RegisterControllers(typeof(MvcApplication).Assembly);
            constructor.RegisterApiControllers(typeof(MvcApplication).Assembly); //Configuracion para la api
            constructor.RegisterType<DataRestaurante>()
                      .As<IRestaurante>()
                       //.SingleInstance(); hace una instancia para toda la aplicacion 
                       .InstancePerRequest(); //hace una instancia por cada solicitud
            constructor.RegisterType<DbContextRestaurantes>().InstancePerRequest();
            var contenedor = constructor.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(contenedor); //configuracion para la api
        }
    }
}