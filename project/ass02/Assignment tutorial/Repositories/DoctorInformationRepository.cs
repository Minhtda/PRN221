using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject {
    public class DoctorInformationRepository : GenericRepository<DoctorInformation>, IDoctorInformationRepository {
        public IEnumerable<DoctorInformation> GetDoctorInformationBySearch(string search) {
            return _context.DoctorInformations.Where(dr => dr.DoctorName == search).ToList();
        }
    }
}
