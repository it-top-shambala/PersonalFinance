using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.Lib.DAL
{
    public class PersonalFinanceDbContext : IPersonalFinance
    {
        private readonly string connectionString;
        public PersonalFinanceDbContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }

        /// <summary>
        /// Методы полуения данных из бд
        /// </summary>
        public IEnumerable<Wallet> GetWallets()
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<Wallet>("SELECT wallet_id,tab_wallets.name,tab_currencies.name AS name_currency,balance" +
                " FROM tab_wallets JOIN tab_currencies " +
                "ON tab_wallets.currency_id = tab_currencies.currency_id");
        }
        public IEnumerable<Currency> GetCurrencies()
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<Currency>("SELECT * FROM tab_currencies");
        }
        public IEnumerable<Category> GetCategorys()
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<Category>("SELECT * FROM tab_categories");
        }
        public IEnumerable<Operation> GetLogs(int idWallet)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<Operation>("SELECT operation_id, wallet_id, date_time, tab_categories.name AS name_category, summa " +
                "FROM tab_operations JOIN tab_categories " +
                "ON tab_operations.category_id = tab_categories.category_id AND " +
                "tab_operations.wallet_id = " + $"{idWallet}");
        }

        public Wallet GetWallet(int id)
        {
            var query = "SELECT wallet_id,tab_wallets.name,tab_currencies.name AS name_currency,balance" +
                " FROM tab_wallets JOIN tab_currencies " +
                "ON tab_wallets.currency_id = tab_currencies.currency_id AND wallet_id=" + $"{id}";
            using var connection = new SqlConnection(connectionString);
            return connection.QuerySingle<Wallet>(query);
        }
        public Category GetCategory(int id)
        {
            var query = "SELECT * FROM tab_categories WHERE category_id=" + $"{id}";
            using var connection = new SqlConnection(connectionString);
            return connection.QuerySingle<Category>(query);
        }

        /// <summary>
        /// Методы добавления данных в бд
        /// </summary>
        public int CreateWallet(Wallet wallet)
        {
            using var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM tab_wallets WHERE name = " + $"{wallet.Name}";
            var result = connection.Execute(query);
            if (result >= 1)
            {
                return -1;
            }
            else
            {
                query = "INSERT INTO tab_wallets (name,balance,currency_id) VALUES (@Name,@Balance,@IdCurrancy); SELECT CAST(SCOPE_IDENTITY() as int)";
                return connection.Query<int>(query, wallet).FirstOrDefault();
            }
        }
        public int CreateCategory(Category category)
        {
            using var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM tab_categories WHERE name = " + $"{category.Name}";
            var result = connection.Execute(query);
            if (result >= 1)
            {
                return -1;
            }
            else
            {
                query = "INSERT INTO tab_categories (name,type) VALUES (@Name,@Type); SELECT CAST(SCOPE_IDENTITY() as int)";
                return connection.Query<int>(query, category).FirstOrDefault();
            }
        }

        /// <summary>
        /// Методы удаления данных из бд
        /// </summary>
        public int DeleteWallet(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM tab_wallets WHERE wallet_id= @id";
            return connection.Execute(query, new { id });
        }
        public int DeleteCategory(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var query = "DELETE FROM tab_categories WHERE category_id= @id";
            return connection.Execute(query, new { id });
        }

        /// <summary>
        /// Методы измения данных
        /// </summary>
        public bool UpdateWallet(int id, string newName)
        {
            using var connection = new SqlConnection(connectionString);
            var check = "SELECT * FROM tab_wallets WHERE name = " + $"{newName}";
            var result = connection.Execute(check);
            if (result >= 1)
            {
                return false;
            }
            else
            {
                var query = "UPDATE tab_wallets SET name = " + $"{newName} WHERE wallet_id = " + $"{id}";
                var res = connection.Execute(query);
                return res != 0;
            }
        }
        public bool UpdateCategory(int id, string newName)
        {
            using var connection = new SqlConnection(connectionString);
            var check = "SELECT * FROM tab_categories WHERE name = " + $"{newName}";
            var result = connection.Execute(check);
            if (result >= 1)
            {
                return false;
            }
            else
            {
                var query = "UPDATE tab_categories SET name = " + $"{newName} WHERE category_id = " + $"{id}";
                var res = connection.Execute(query);
                return res != 0;
            }
        }

        /// <summary>
        /// Метод транзакции
        /// </summary>
        public bool Transaction(int walletId, int categoryId, double summa)
        {
            using var connection = new SqlConnection(connectionString);
            var queryInsert = "INSERT INTO tab_operations (date_time,wallet_id,category_id,summa)" +
                "VALUES (GETDATE(),@WalletId,@CategoryId,@Summa)";
            var result = connection.Execute(queryInsert, new { WalletId = walletId, CategoryId = categoryId, Summa = summa });
            if (result == 0)
            {
                return false;
            }
            else
            {
                var queryUpdate = "UPDATE tab_wallets SET balance=balance+@Summa WHERE wallet_id=@WalletId";
                var res = connection.Execute(queryUpdate, new { Summa = summa, WalletId = walletId });
                return res != 0;
            }
        }
    }
}









