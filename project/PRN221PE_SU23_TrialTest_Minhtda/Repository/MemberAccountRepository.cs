using BusinessObject.Models;
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MemberAccountRepository : GenericRepository<MemberAccount>, IMemberAccountRepository
    {
        public MemberAccount GetMemberAccountByEmail(string email, string password)
        {
            return _context.MemberAccounts.FirstOrDefault(x => x.EmailAddress == email && x.MemberPassword == password);
        }
    }
}
