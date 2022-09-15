using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Globalization;
using ValidationProject.Validations.ValidationRules;

using ValidationProject.Static;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ValidationProject.Validations
{
    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                string nameToValidate = (string) value;
                NameValidationRules nvr=new NameValidationRules(nameToValidate);
                ProjectLocalization projectLocalization = new ProjectLocalization();

                string errContent = string.Empty;
                if (nvr.IsNameShort)
                {       
                    errContent= projectLocalization.GetStringResource("validationNameIsShort");
                }
                if (nvr.IsNameLong)
                {
                    errContent = projectLocalization.GetStringResource("validationNameIsLong");
                }
                if (!nvr.IsFirstLetterUppercase)
                {
                    errContent = projectLocalization.GetStringResource("validationNameFirstLetterNotUppercase");
                }
                if (!nvr.IsOtherLetterLowercase)
                {
                    errContent = projectLocalization.GetStringResource("validationOtherLetterNotLowercase");
                }
                if (!nvr.IsOnlyLetters)
                {
                    errContent = projectLocalization.GetStringResource("validationNameOnlyLetters");
                }
                return new ValidationResult(false, errContent);

            }
            return new ValidationResult(true, "");
        }
    }
}
