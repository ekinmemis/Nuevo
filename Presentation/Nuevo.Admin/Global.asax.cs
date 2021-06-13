using Nuevo.Admin.Configurations;
using Nuevo.Admin.Infrastructure;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using static Nuevo.Admin.Infrastructure.CustomSearchModelBinding;

namespace Nuevo.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Configurations
            AutofacConfiguration.Configure();
            AutoMapperConfiguration.Configure();

            //Infrastructure
            ModelBinderProviders.BinderProviders.Insert(0, new DataTablesToObjectModelBinderProvider());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        }
    }
}
