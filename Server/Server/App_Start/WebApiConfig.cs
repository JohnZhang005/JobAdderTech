using System.Net.Http.Formatting;
using System.Web.Http;
using Server.Interfaces;
using Server.Repository;
using Server.Services;
using Unity;
using Unity.WebApi;

namespace Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable Cors
            config.EnableCors();
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ILocalDataRepository, LocalDataRepository>();
            container.RegisterType<IFindBestCandidateService, FindBestCandidateService>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{page}",
                defaults: new { id = RouteParameter.Optional, page = RouteParameter.Optional }
            );
        }
    }
}
