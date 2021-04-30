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

            string careLevel = "3c";

            List<Resident> residentList = _queryService.FilterResidentsByCareLevel(careLevel);
            Console.WriteLine($"Es gibt {residentList.Count} Bewohner mit Carelevel {careLevel}.");

            int numberOfCategories = _queryService.CountNumberOfEquipmentCategories();
            Console.WriteLine($"Es gibt {numberOfCategories} Equipment-Kategorien.");

            string equipmentCategory = "standard";

            List<Resident> residentList2 = _queryService.FilterResidentByRoomEquipment(equipmentCategory);
            Console.WriteLine($"Es gibt {residentList2.Count} Bewohner mit der Equipmentkategorie {equipmentCategory}.");

            List<Resident> residentList3 = _queryService.FilterResidentsByAge(88, 89);
            foreach (Resident res in residentList3) {
                Console.WriteLine("{0} {1}, {2}", res.Prename, res.LastName, res.Age);
            }



        }
    }
}
