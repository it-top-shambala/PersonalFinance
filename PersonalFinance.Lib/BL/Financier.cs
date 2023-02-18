using PersonalFinance.Lib.DAL;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.Lib.BL
{
    public class Financier
    {
        private readonly IPersonalFinance _db;

        public Financier(IPersonalFinance db)
        {
            _db = db;
        }

        public IEnumerable<Wallet> GetAllWallets()
        {
            return _db.GetWallets();
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _db.GetCurrencies();
        }

        public (IEnumerable<Category> income, IEnumerable<Category> expense) GetAllCategories()
        {
            var categories = _db.GetCategories();
            var income = categories.Where((c) => c.Type);
            var expense = categories.Where((c) => !c.Type);
            return (income, expense);
        }

        public Wallet? CreateWallet(string name, Currency currency, double startSum)
        {
            var id = _db.CreateWallet(name, currency, startSum);
            return _db.GetWallet(id) ?? null;
        }

        public Category? CreateCategory(string name, bool type)
        {
            var id = _db.CreateCategory(name, type);
            return _db.GetCategory(id) ?? null;
        }

        public IEnumerable<Operation> GetAllWalletOperations(int walletId)
        {
            return _db.GetLogs(walletId);
        }

        public IEnumerable<Operation> GetFilteredWalletOperations(int walletId, int categoryId)
        {
            return _db.GetLogs(walletId, categoryId);
        }

        public void EditCategoryName(int categoryId, string newName)
        {
            _ = _db.UpdateCategory(categoryId, newName);
        }

        public Wallet EditWalletName(int walletId, string newName)
        {
            _ = _db.UpdateWallet(walletId, newName);
            return _db.GetWallet(walletId);
        }

        public (Wallet wallet, Operation operation) MakeWalletOperation(int walletId, int categoryId, double sum)
        {
            var res = _db.Transaction(walletId, categoryId, sum);
            return (_db.GetWallet(walletId), res.Item2!);
        }
    }
}
