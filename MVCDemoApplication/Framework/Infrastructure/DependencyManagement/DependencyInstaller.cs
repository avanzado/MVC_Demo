
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;

namespace Framework.Infrastructure.DependencyManagement
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(
            //            Component.For<ILogService>()
            //                .ImplementedBy<LogService>()
            //                .LifeStyle.PerWebRequest,

            //            Component.For<IDatabaseFactory>()
            //                .ImplementedBy<DatabaseFactory>()
            //                .LifeStyle.PerWebRequest,

            //            Component.For<IUnitOfWork>()
            //                .ImplementedBy<UnitOfWork>()
            //                .LifeStyle.PerWebRequest,

            //            AllTypes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

            //            AllTypes.FromAssemblyNamed("LayerService")
            //                .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces().LifestylePerWebRequest(),

            //            AllTypes.FromAssemblyNamed("DataAccess")
            //                .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces().LifestylePerWebRequest()
            //            );
        }

    }
}