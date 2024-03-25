using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations;

namespace UdemyWebApp8.CustomValidate
{
    public class CustomValidate1 : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string valueString = value as string;
            if (valueString.Length > 12 || valueString.Length < 2)
            {
                return new ValidationResult($"{validationContext.DisplayName} should be had length between 2 and 12");
            }
            
            return ValidationResult.Success;
        }
    }
}
