using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public interface ILoginWithService
    {
        Task<string> LoginFirebase(string mail, string password);
    }
}
