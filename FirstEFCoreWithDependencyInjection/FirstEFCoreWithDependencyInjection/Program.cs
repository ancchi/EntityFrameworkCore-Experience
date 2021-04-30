using Autofac;
using FirstEFCoreWithDependencyInjection;
using FirstEFCoreWithDependencyInjection.Models;
using System;

namespace FirstEFCoreWithDependencyInjection {
    class Program {
        static void Main(string[] args) {

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope()) { // "lebt" solange die Applikation läuft
                var app = scope.Resolve<IApplication>(); // Resolve ist so ähnlich wie der "new"-Operator; eine neue Instanz wird erstellt
                
                app.Run(); // Run() ruft den LifetimeScope ins Leben, von wo aus es (Run()) Dependencies auflösen kann

                /**
                 * - um app.Run() ausführen zu können wird scope.Resolve<IApplication>() ausgeführt
                 * - Autofac sieht, dass IApplication die Klasse Application mappt und startet mit der Konstrukation einer Application-Instanz
                 * - Autofac sieht, dass Application einen IDBService und einen IQueryService für den Konstruktor braucht
                 * - Autofac sieht, dass diese beiden Interfaces DBService und QueryService mappen und erstellt deshalb für beide Instanzen
                 * - Autofac verwendet diese beiden Instanzen um die Konstruktion der Application-Instanz abzuschließen
                 * - Autofac gibt die vollständig konstruierte Application-Instanz zurück, damit dann darauf die Methode "Run()" aufgerufen werden kann.
                 * 
                 * - ist die Methode durchgelaufen, wird der Autofac Lifetimescope "entsorgt" und alle "wegwerfbaren" Ressourcen, die mit diesem
                 *   Scope ins Leben gerufen wurden, ebenfalls
                 * */
            }

        }

        
    }
}
