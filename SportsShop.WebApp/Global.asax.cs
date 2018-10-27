namespace SportsShop.WebApp
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using SportsShop.Domain.Entities;
    using SportsShop.WebApp.Infrastructure.Binders;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.Register();

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
