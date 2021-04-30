using Autofac;
using System.Linq;
using System.Reflection;

namespace FirstEFCoreWithDependencyInjection {
    public static class ContainerConfig {

        public static IContainer Configure() {

            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            /*builder.RegisterType<DBService>().As<IDBService>();

            builder.RegisterType<QueryService>().As<IQueryService>();*/


            // automatisch die Types/Klassen und Interfaces ermitteln

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()) // automatisch ausführende Assembly ermitteln
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(FirstEFCoreWithDependencyInjection))) // spezifische Assembly
                .Where(t => t.Namespace.Contains("Services"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
