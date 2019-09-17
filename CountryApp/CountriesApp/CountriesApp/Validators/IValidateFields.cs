using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Validators
{
    public interface IValidateFields
    {
        ResponseValidator ValidateCredentials(string email, string password);
    }
}
