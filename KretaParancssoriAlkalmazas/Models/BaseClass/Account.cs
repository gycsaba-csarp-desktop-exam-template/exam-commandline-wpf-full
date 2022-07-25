using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.BaseClass
{
    public class Account : IAccount, IComparable, IEquatable<Account>
    {
        public string LoginName { get; set; }
        public string Password { get; set; }

        public Account(string loginName, string password)
        {
            LoginName = loginName;
            Password = password;
        }

        public bool Equals(Account other)
        {
            if (!(other is Account))
                return false;
            else
            {
                Account otherAccount = (Account)other;
                if (this.LoginName.Equals(otherAccount.LoginName) && (this.Password.Equals(otherAccount.Password)))
                    return true;
                else
                    return false;

            }
            
        }

        public int GetHashCode([DisallowNull] Account obj)
        {
            return LoginName.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Account))
                return 0;
            {
                Account objAccount = (Account)obj;
                return this.LoginName.CompareTo(objAccount.LoginName);
            }
 
        }

    }
}
