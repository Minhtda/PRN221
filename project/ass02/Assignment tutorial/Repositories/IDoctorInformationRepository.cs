using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject {
    public interface IDoctorInformationRepository : IGenericRepository<DoctorInformation> {
        IEnumerable<DoctorInformation> GetDoctorInformationBySearch(string search);
    }
}
