using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using System.Text.RegularExpressions;

namespace API.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClientEntityValidationAttribute : ValidationAttribute
    {
        public ClientEntityValidationAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = validationContext.GetService(typeof(DataContext)) as DataContext;
            var client = value as Client;

            if (dbContext.Clients.Where(x => x.Id != client.Id).Any(x => x.PassportNumber == client.PassportNumber
                                        && x.PassportSerial == client.PassportSerial))
            {
                return new ValidationResult("User with same PasswordSerial, PasswordNumber exists");
            }

            if (dbContext.Clients.Where(x => x.Id != client.Id).Any(x => x.IdentifyNumber == client.IdentifyNumber))
            {
                return new ValidationResult("User with same IdentifyNumber exists");
            }

            if (client.Name.All(x => char.IsDigit(x)) || client.Surname.All(x => char.IsDigit(x)) || client.FatherName.All(x => char.IsDigit(x)))
            {
                return new ValidationResult("Name, Surname, FatherName should not be a number");
            }

            return ValidationResult.Success;
        }
    }
}
