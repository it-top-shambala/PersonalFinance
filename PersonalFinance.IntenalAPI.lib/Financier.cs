using PersonalFinance.IntenalAPI.lib;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.IntenalAPI.Lib
{
    internal class Financier
    {
        internal static IEnumerable<Wallet> GetAllWallets() // получение всех кошельков из бд
        {
            yield return new Wallet();
        }

        IEnumerable<Currency> GetAllCurrencies() // получение всех валют из бд
        {
            yield return new Currency();
        }

        (IEnumerable<Category> Income, IEnumerable<Category> Expense) GetAllCategories() // метод возвращает кортеж из двух перечислителей категорий из бд, отфильтрованных по значению Type
        {
            var db = new PersonalFinanceDbContext().GetCategorys();
            var Income = from cat in db
                         where cat.Type = "Income"
                         select cat;
            var Expense = from cat in db
                          where cat.Type = "Expence"
                          select cat;
            return (Income, Expense);
        }

        internal static Wallet CreateWallet(string name, Currency currency, double startSum) // метод создает и возвращает кошелек с полученным из бд id
        {
            var currencyExchangeRate = ExchangeRateAPI.ExchangeRate(currency.Code);
            var wallet =new Wallet();
            var db = new PersonalFinanceDbContext().CreateWallet(Wallet wallet)
        }

        internal static Category CreateCategory(string name, bool type) // метод создает и возвращает категорию с полученным из бд id
        {

        }

        internal static IEnumerable<Operation> GetAllWalletOperations(int walletId) // получение списка всех операций кошелька
        {

        }

        internal static IEnumerable<Operation> GetFilteredWalletOperations(int walletId, int categoryId) // возвращать  будет операции с именем категории для показа, без id
        {

        }

        internal static Wallet MakeWalletOperation(double sum) // метод совершает операцию и возвращает кошелек из бд с обновленным балансом.
        {
            return new Wallet { };
        }
        internal static (Wallet, Operation) MakeWalletOperation(int walletId, int categoryId, double sum) // метод совершает операцию, возвращает обновленный кошелёк из бд и саму новую операцию с полученным id
        {
            return (new Wallet(), new Operation());
        }
        internal static void EditCategoryName(int categoryId, string newName) // метод редактирует название категории
        {

        }

        internal static Wallet EditWalletName(int walletId, string newName) // метод редактирует название кошелька и возвращает обновленный кошелек из бд
        {
            return new Wallet { };
        }

    }
}
