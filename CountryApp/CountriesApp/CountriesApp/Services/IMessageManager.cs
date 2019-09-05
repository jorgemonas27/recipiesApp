using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public interface IMessageManager
    {
         void ShowMessage(string title, string message, string confirm = "Ok");
    }
}
