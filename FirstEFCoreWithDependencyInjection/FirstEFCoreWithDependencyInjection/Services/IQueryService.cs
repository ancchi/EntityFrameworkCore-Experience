using FirstEFCoreWithDependencyInjection.Models;
using System.Collections.Generic;


namespace FirstEFCoreWithDependencyInjection.Services {
    public interface IQueryService {

        List<Resident> FilterResidentsByCareLevel(string careLevel);

        List<Resident> FilterResidentByRoomEquipment(string equipment);
        int CountNumberOfEquipmentCategories();

        List<Resident> FilterResidentsByAge(int minAge, int maxAge);
    }
}
