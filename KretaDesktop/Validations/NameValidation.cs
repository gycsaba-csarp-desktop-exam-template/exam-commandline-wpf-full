using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Globalization;
using ValidationProject.Validations.ValidationRules;

using ValidationProject.Static;

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

                if (nvr.IsNameShort)
                {
        
                    string errContent= projectLocalization.GetStringResource("validationNameIsShort");
                    return new ValidationResult(false, errContent);
                }

                if (!nvr.IsFirstLetterUppercase)
                {
                    string errContent = projectLocalization.GetStringResource("validationNameFirstLetterNotUppercase");
                    return new ValidationResult(false, errContent);
                }
                if (!nvr.IsOtherLetterLowercase)
                {
                    string errContent = projectLocalization.GetStringResource("validationOtherLetterNotLowercase");
                    return new ValidationResult(false, errContent);
                }
                if (!nvr.IsOnlyLetters)
                {
                    string errContent = projectLocalization.GetStringResource("validationNameOnlyLetters");
                    return new ValidationResult(false, errContent);
                }
            }
            return new ValidationResult(true, "");
        }
    }
}
