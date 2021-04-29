using FirstEFCoreWithDependencyInjection.Models;
using FirstEFCoreWithDependencyInjection.Services;
using System;
using System.Collections.Generic;

namespace FirstEFCoreWithDependencyInjection {
    class Application : IApplication {

        IDBService _dbService;
        IQueryService _queryService;

        public Application(IDBService dBService, IQueryService queryService) {
            _dbService = dBService;
            _queryService = queryService;
        }

        public void Run() {
            Resident resident =_dbService.FindResidentById(3);
            Console.WriteLine($"{resident.Prename} {resident.LastName}\nAlter: {resident.Age}");
            Console.WriteLine();

            string careLevel = "1a";

            List<Resident> residentList = _queryService.FilterResidentsByCareLevel(careLevel);
            Console.WriteLine($"Es gibt {residentList.Count} Bewohner mit Carelevel {careLevel}:");
            foreach (Resident res in residentList) {
                Console.WriteLine("{0} {1}", res.Prename, res.LastName);

            }
        }
    }
}
