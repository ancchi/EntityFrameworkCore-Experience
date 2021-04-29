using Autofac;
using FirstEFCoreWithDependencyInjection;
using FirstEFCoreWithDependencyInjection.Models;
using System;

namespace FirstEFCoreWithDependencyInjection {
    class Program {
        static void Main(string[] args) {

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope()) {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

        }

        
    }
}
