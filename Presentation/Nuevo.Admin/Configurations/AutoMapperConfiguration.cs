using AutoMapper;

using Core.Domain.ApplicationUsers;

using Nuevo.Admin.Models.AccountModels;
using Nuevo.Admin.Models.ResidanceModels;
using Nuevo.Core.Domain.Residances;

namespace Nuevo.Admin.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, RegisterModel>();
                cfg.CreateMap<RegisterModel, ApplicationUser>().IgnoreAllVirtual();

                cfg.CreateMap<Residance, ResidanceModel>();
                cfg.CreateMap<ResidanceModel, Residance>().IgnoreAllVirtual();
            });



            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}