using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StaffAccountRepository : GenericRepository<StaffAccount>, IStaffAccountRepository
    {
        public StaffAccount GetStaffAccountByEmail(string email, string password)
        {
            return _context.StaffAccounts.FirstOrDefault(x => x.Hremail == email && x.Hrpassword == password);
        }
        public Boolean CreateAccount(StaffAccount account){
            
            return false;
        }
    }
}
