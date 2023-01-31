using PersonalFinance.Lib.Models;

namespace PersonalFinance.Lib.DAL
{
    public interface IPersonalFinance
    {
        IEnumerable<Wallet> GetWallets();
        IEnumerable<Currency> GetCurrencies();
        IEnumerable<Category> GetCategorys();
        IEnumerable<Operation> GetLogs(int idWallet);

        Wallet GetWallet(int id);
        Category GetCategory(int id);

        int CreateWallet(Wallet wallet);
        int CreateCategory(Category category);

        int DeleteWallet(int id);
        int DeleteCategory(int id);

        bool UpdateWallet(int id, string newName);
        bool UpdateCategoryg(int id, string newName);

        bool Transaction(int walletId, int categoryId, double summa);
    }
}
