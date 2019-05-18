using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektRaport.Validators
{
    public class FirstCharIsBig : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                string Name = value.ToString().Trim();

                string firstLetter = Name[0].ToString();
                if(firstLetter.Any(char.IsUpper))
                    return ValidationResult.Success;
                else
                {
                    return new ValidationResult("Pierwsza litera imienia musi być wielka.");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}