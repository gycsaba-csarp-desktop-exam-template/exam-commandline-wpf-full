using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public class Account : IAccount, IComparable, IEquatable<Account>
    {
        public long Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        public Account()
        {
            Id = -1;
            LoginName=String.Empty;
            Password=String.Empty;
        }

        public Account(long id, string loginName, string password)
        {
            Id = id;
            LoginName = loginName;
            Password = password;
        }

        public bool Equals(Account other)
        {
            if (!(other is Account))
                return false;
            else
            {
                Account otherAccount = other;
                if (LoginName.Equals(otherAccount.LoginName) && Password.Equals(otherAccount.Password))
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
                return LoginName.CompareTo(objAccount.LoginName);
            }

        }

    }
}
