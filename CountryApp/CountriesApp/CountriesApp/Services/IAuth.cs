using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public interface IAuth
    {
        Task<bool> LoginUser(string email, string password);
        Task<string> LoginFirebaseService(string email, string password);
    }
}
