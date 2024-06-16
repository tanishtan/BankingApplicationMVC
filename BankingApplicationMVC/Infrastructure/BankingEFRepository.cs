using BankingApplicationMVC.Models;

namespace BankingApplicationMVC.Infrastructure
{
    public class BankingEFRepository : IRepository<Bank, int>
    {
        private readonly Bank _db;
        public BankingEFRepository() => _db = new Bank();

        public void AccountTransaction(Bank account, int amount, int choice)
        {
            throw new NotImplementedException();
        }

        public void CreateNewAccount(int id, int name, Bank type, int amount)
        {
            throw new NotImplementedException();
        }

        public Bank FindAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public void FundTransfer(Bank account1, Bank account2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bank> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bank> GetBy(string filterCriteria)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccountDetails(Bank account, int Id, int Name, int Balance)
        {
            throw new NotImplementedException();
        }
    }
}
