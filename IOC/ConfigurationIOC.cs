using Adapter.Interfaces;
using Adapter.Mapper;
using Application.Interfaces;
using Application.Services;
using Autofac;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Repositories;
using Core.Services;
using Repository.Repositories;
using Services;
using Services.Services;

namespace IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC Application
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            builder.RegisterType<ApplicationServiceEvent>().As<IApplicationServiceEvent>();
            builder.RegisterType<ApplicationServiceUserEvent>().As<IApplicationServiceUserEvent>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            builder.RegisterType<ServiceEvent>().As<IServiceEvent>();
            builder.RegisterType<ServiceUserEvent>().As<IServiceUserEvent>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            builder.RegisterType<RepositoryEvent>().As<IRepositoryEvent>();
            builder.RegisterType<RepositoryUserEvent>().As<IRepositoryUserEvent>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperUser>().As<IMapperUser>();
            builder.RegisterType<MapperEvent>().As<IMapperEvent>();
            builder.RegisterType<MapperUserEvent>().As<IMapperUserEvent>();
            #endregion
        }
    }
}
