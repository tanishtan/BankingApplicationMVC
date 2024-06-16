namespace BankingApplicationMVC.Infrastructure
{
    public interface IRepository<TEntity, TIdentity>
    {
        IEnumerable<TEntity> GetAllAccounts();
        IEnumerable<TEntity> GetBy(string filterCriteria);
        TEntity FindAccountById(TIdentity id);
        void CreateNewAccount(TIdentity id, TIdentity name, TEntity type, TIdentity amount);
        void UpdateAccountDetails(TEntity account, TIdentity Id, TIdentity Name, TIdentity Balance);
        void AccountTransaction(TEntity account, TIdentity amount, TIdentity choice);
        void FundTransfer(TEntity account1, TEntity account2);
        void RemoveAccountById(TIdentity id);
    }
}
