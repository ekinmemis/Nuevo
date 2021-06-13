
using Autofac;
using Autofac.Integration.Mvc;

using Nuevo.Web.Paging;

using Nuevo.Data.EfRepository;
using Nuevo.Service.Authentication;
using Nuevo.Services.ApplicationUserServices;
using Nuevo.Services.ResidanceServices;
using Nuevo.Web.Factories.Residances;
using Nuevo.Web.Models.Residances;

using System.Linq;
using System.Web.Mvc;

namespace Nuevo.Web.Configurations
{
    public class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationUserService>().As<IApplicationUserService>();
            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<ResidanceService>().As<IResidanceService>();
            builder.RegisterType<ResidanceModelFactory>().As<IResidanceModelFactory>();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
                       .Where(t => t.Name.EndsWith("Controller"));

            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}