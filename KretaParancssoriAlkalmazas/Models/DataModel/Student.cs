using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.DataModel
{
    public class Student : Person
    {
        public IAccount? Account { get; }
        public IAddress? Address { get; set; }

        public Student(long id, string firstName, string lastName, bool woman, DateTime dateOfBirth, IAddress address, IAccount account)
            : base(id, firstName, lastName, woman, dateOfBirth)
        {
            Account = account;
            Address = address;
        }

        public Student() : base()
        {
            Account = null;
            Address = null;
        }
    }
}
