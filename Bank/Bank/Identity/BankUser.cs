using System.Collections.Generic;

namespace Bank.Identity
{
    public class BankUser
    {
        public Credentials Credentials { get; set; }


        public Gender Gender { get; set; }

        public List<AccountID> Accounts;

        public string Email { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        public string FullName => $"{FirstName} {LastName}";

        public BankUser(string userName, string password)
        {
            Credentials = new Credentials(userName, password);

            Accounts = new List<AccountID>();
        }
    }
}