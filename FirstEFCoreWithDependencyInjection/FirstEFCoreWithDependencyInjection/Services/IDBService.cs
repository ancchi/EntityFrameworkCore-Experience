using FirstEFCoreWithDependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreWithDependencyInjection.Services {
    public interface IDBService {

        Resident FindResidentById(int residentId);

        List<CareTaker> GetCaretTakerListForResidentId(int residentId);

        List<Visitor> GetVisitorListForResidentId(int residentId);

        List<Resident> GetResidentListForCareTakerId(int careTakerId);


        Resident UpdateNameResident(int residentId, string preName, string lastName);

        void DeleteResidentWithVisitors(int residentId);

    }
}
