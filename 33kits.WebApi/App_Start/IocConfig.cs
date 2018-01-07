using System.Reflection;
using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.WebApi;
using CommonContracts;
using Migrator.Migrations;
using Orm;
using _33kits.Contracts.Interfaces;
using _33kits.WebApi.Infrastructure;
using _33Kits.DataRepository;

namespace _33kits.WebApi.App_Start
{
    public class IocConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<NLogModule>();

            builder.RegisterType<CommonDb>().As<ICommonDb>().InstancePerRequest();
            builder.RegisterType<GlobalSettings>().As<IGlobalSettings>().SingleInstance();
            builder.RegisterType<BinaryHelper>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<ImagesRepository>().As<IImagesRepository>().InstancePerRequest();
            builder.RegisterType<MenuOnDayRepository>().As<IMenuOnDayRepository>().InstancePerRequest();
            builder.RegisterType<DishRepository>().As<IDishRepository>().InstancePerRequest();
            builder.RegisterType<DishListRepository>().As<IDishListRepository>().InstancePerRequest();
            builder.RegisterType<Migrator.Migrator>().As<IMigrator>().InstancePerRequest();
        }
    }
}