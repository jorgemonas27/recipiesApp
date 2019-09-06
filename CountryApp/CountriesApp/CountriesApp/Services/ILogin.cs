using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public interface ILogin
    {
        Task<bool> LoginUser(string email, string password);
    }
}
