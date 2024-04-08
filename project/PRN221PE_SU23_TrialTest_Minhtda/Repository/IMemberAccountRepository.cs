using BusinessObject.Models;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMemberAccountRepository : IGenericRepository<MemberAccount>
    {
        public MemberAccount GetMemberAccountByEmail(string email, string password);
    }
}
