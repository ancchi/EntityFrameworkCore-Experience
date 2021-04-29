using Autofac;
using FirstEFCoreWithDependencyInjection.Services;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreWithDependencyInjection {
    public static class ContainerConfig {

        public static IContainer Configure() {

            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            /*builder.RegisterType<DBService>().As<IDBService>();

            builder.RegisterType<QueryService>().As<IQueryService>();*/

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace.Contains("Services"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
