using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.DataModel
{
    public class StudentWithScholarship : Person, IScholarship
    {
        public IAccount? Account { get; }
        public IAddress? Address { get; set; }
        public ulong TaxNumber { get; set; }
        public ulong Amount { get; set; }

        public StudentWithScholarship(long id, string firstName, string lastName, bool woman, DateTime dateOfBirth, IAddress address, IAccount account, ulong taxNumber, ulong amount)
            : base(id, firstName, lastName, woman, dateOfBirth)
        {
            TaxNumber = taxNumber;
            Amount = amount;
            Account = account;
            Address = address;
        }

        public StudentWithScholarship() : base()
        {
            TaxNumber = ulong.MaxValue;
            Amount = ulong.MaxValue;
            Account = null;
            Address = null;
        }
    }
}
