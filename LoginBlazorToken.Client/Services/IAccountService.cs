using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginBlazorToken.Client.Services
{
    public interface IAccountService
    {
        bool Login();
        bool Logout();
    }
}
