using System;

namespace Bank.Identity
{
    public class AccountID
    {
        private Guid Guid;

        public AccountID()
        {
            Guid = Guid.NewGuid();
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}