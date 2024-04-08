using BussinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStaffAccountRepository : IGenericRepository<StaffAccount>
    {
        public StaffAccount GetStaffAccountByEmail(string email, string password);
    }
}
