using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationProject.Validations.ValidationRules
{
    public class NameValidationRules
    {
        private readonly string nameToValidate;

        public NameValidationRules(string name)
        {
            this.nameToValidate = name;
        }


        public bool IsNameShort
        {
            get
            {
                if (nameToValidate.Length <= 3)
                    return true;
                else
                    return false;
            }
        }

        public bool IsFirstLetterUppercase
        {
            get
            {
                if (nameToValidate.Length > 0)
                {
                    if (char.IsUpper(nameToValidate.ElementAt(0)))
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
        }

        public bool IsOtherLetterLowercase
        {
            get
            {
                if (nameToValidate.Length >= 2)
                {
                    for (int i=1;i<nameToValidate.Length;i=i+1)
                    {
                        if (char.IsUpper(nameToValidate.ElementAt(i)))
                            return false;
                    }
                    return true;
                }
                return true;
            }
        }

        public bool IsOnlyLetters => this.nameToValidate.All(Char.IsLetter);
    }
}
