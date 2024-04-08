using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ILoginController
    {
        public Boolean Login(string username, string password);
    }
}
