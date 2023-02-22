using PersonalFinance.Lib.Models;

namespace PersonalFinance.Lib.DAL
{
    public interface IPersonalFinance
    {
        IEnumerable<Wallet> GetWallets();
        IEnumerable<Currency> GetCurrencies();
        IEnumerable<Category> GetCategories();
        IEnumerable<Operation> GetLogs(int idWallet);
        IEnumerable<Operation> GetLogs(int idWallet, int categoryId);

        Wallet GetWallet(int id);
        Category GetCategory(int id);

        int CreateWallet(string name, Currency currency, double startSum);

        void AddWalletBackground(int walletId, string background);

        IEnumerable<(int, string)> GetWalletBackgrounds();

        int CreateCategory(string name, bool type);

        int DeleteWallet(int id);
        int DeleteCategory(int id);

        bool UpdateWallet(int id, string newName);
        bool UpdateCategory(int id, string newName);

        (bool, Operation?) Transaction(int walletId, int categoryId, double summa);
    }
}
