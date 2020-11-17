namespace Bank.Identity
{
    public class BankUser
    {
        public string UserName { get; }

        public string Password { get; private set; }
        public string Email { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        public BankUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}