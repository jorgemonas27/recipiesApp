using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public interface IAuth
    {
        Task<bool> LoginUser(string email, string password);
        bool IsUserSign();
        bool LogoutUser();
    }
}
