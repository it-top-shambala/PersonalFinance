using Dapper;
using MySql.Data.MySqlClient;
using PersonalFinance.Lib.Models;
using Operation = PersonalFinance.Lib.Models.Operation;

namespace PersonalFinance.Lib.DAL
{
    public class PersonalFinanceDbContext : IPersonalFinance
    {
        private readonly string connectionString;
        public PersonalFinanceDbContext()
        {
            connectionString = DbConfig.GetConnectionString("constr.txt");
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        /// <summary>
        /// Методы полуения данных из бд
        /// </summary>
        public IEnumerable<Wallet> GetWallets()
        {
            using var conn = new MySqlConnection(connectionString);
            return conn.Query<Wallet>("SELECT wallet_id,tab_wallets.wallet_name,tab_currencies.currency_name AS currency_name,balance" +
                " FROM tab_wallets JOIN tab_currencies " +
                "ON tab_wallets.currency_id = tab_currencies.currency_id");
        }
        public IEnumerable<Currency> GetCurrencies()
        {
            using var conn = new MySqlConnection(connectionString);
            return conn.Query<Currency>("SELECT * FROM tab_currencies");
        }
        public IEnumerable<Category> GetCategories()
        {
            using var conn = new MySqlConnection(connectionString);
            return conn.Query<Category>("SELECT * FROM tab_categories");
        }
        public IEnumerable<Operation> GetLogs(int idWallet)
        {
            using var conn = new MySqlConnection(connectionString);
            return conn.Query<Operation>("SELECT operation_id, wallet_id, operation_date, tab_categories.category_name AS category_name, sum " +
                "FROM tab_operations JOIN tab_categories " +
                "ON tab_operations.category_id = tab_categories.category_id WHERE " +
                "wallet_id = " + $"{idWallet}");
        }

        public IEnumerable<Operation> GetLogs(int idWallet, int categoryId)
        {
            using var conn = new MySqlConnection(connectionString);
            return conn.Query<Operation>("CREATE VIEW temp_view AS SELECT * FROM tab_operations " +
                $"WHERE wallet_id = {idWallet} AND category_id = {categoryId}; " +
                "SELECT operation_id, wallet_id, operation_date, category_name, sum " +
                "FROM temp_view JOIN tab_categories ON tab_categories.category_id = temp_view.category_id; " +
                "DROP VIEW temp_view;");
        }

        public Wallet GetWallet(int id)
        {
            var query = "SELECT wallet_id,tab_wallets.wallet_name,tab_currencies.currency_name AS currency_name,balance" +
                " FROM tab_wallets JOIN tab_currencies " +
                "ON tab_wallets.currency_id = tab_currencies.currency_id AND wallet_id=" + $"{id}";
            using var connection = new MySqlConnection(connectionString);
            return connection.QuerySingle<Wallet>(query);
        }
        public Category GetCategory(int id)
        {
            var query = "SELECT * FROM tab_categories WHERE category_id=" + $"{id}";
            using var connection = new MySqlConnection(connectionString);
            return connection.QuerySingle<Category>(query);
        }

        /// <summary>
        /// Методы добавления данных в бд
        /// </summary>
        public int CreateWallet(string name, Currency currency, double startSum)
        {
            using var connection = new MySqlConnection(connectionString);
            var query = $"INSERT INTO tab_wallets (wallet_name,balance,currency_id) VALUES ('{name}',{startSum},{currency.CurrencyId});";
            var result = connection.Execute(query);
            if (result == 0)
            {
                return -1;
            }
            else
            {
                query = "SELECT MAX(wallet_id) FROM tab_wallets;";
                return connection.Query<int>(query).First();
            }
        }
        public int CreateCategory(string name, bool type)
        {
            using var connection = new MySqlConnection(connectionString);
            var query = $"INSERT INTO tab_categories (category_name,type) VALUES ('{name}', {type});";
            var result = connection.Execute(query);
            if (result == 0)
            {
                return -1;
            }
            else
            {
                query = "SELECT MAX(category_id) FROM tab_categories;";
                return connection.Query<int>(query).First();
            }
        }

        /// <summary>
        /// Методы удаления данных из бд
        /// </summary>
        public int DeleteWallet(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            var query = "DELETE FROM tab_wallets WHERE wallet_id= @id";
            return connection.Execute(query, new { id });
        }
        public int DeleteCategory(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            var query = "DELETE FROM tab_categories WHERE category_id= @id";
            return connection.Execute(query, new { id });
        }

        /// <summary>
        /// Методы измения данных
        /// </summary>
        public bool UpdateWallet(int id, string newName)
        {
            using var connection = new MySqlConnection(connectionString);
            var check = "SELECT * FROM tab_wallets WHERE wallet_id = " + $"{id}";
            var result = connection.Execute(check);
            if (result >= 1)
            {
                return false;
            }
            else
            {
                var query = "UPDATE tab_wallets SET wallet_name = " + $"'{newName}' WHERE wallet_id = " + $"{id}";
                var res = connection.Execute(query);
                return res != 0;
            }
        }
        public bool UpdateCategory(int id, string newName)
        {
            using var connection = new MySqlConnection(connectionString);
            var check = "SELECT * FROM tab_categories WHERE category_id = " + $"{id}";
            var result = connection.Execute(check);
            if (result >= 1)
            {
                return false;
            }
            else
            {
                var query = "UPDATE tab_categories SET category_name = " + $"'{newName}' WHERE category_id = " + $"{id}";
                var res = connection.Execute(query);
                return res != 0;
            }
        }

        /// <summary>
        /// Метод транзакции
        /// </summary>
        public (bool, Operation?) Transaction(int walletId, int categoryId, double summa)
        {
            using var connection = new MySqlConnection(connectionString);
            var date = DateTime.Now;
            var textDate = date.ToString("u");
            textDate = textDate.Remove(textDate.Length - 1);
            var queryInsert = $"INSERT INTO tab_operations (operation_date, wallet_id, category_id, sum) VALUES ('{textDate}', {walletId}, {categoryId}, {summa})";
            var result = connection.Execute(queryInsert);
            var queryOperation = $"SELECT operation_id, wallet_id, operation_date, category_name, sum " +
                $"FROM tab_operations JOIN tab_categories ON tab_operations.category_id = tab_categories.category_id " +
                $"WHERE wallet_id={walletId} AND operation_date = '{textDate}'";
            var operation = connection.Query<Operation>(queryOperation).First();
            if (result == 0)
            {
                return (false, null);
            }
            else
            {
                var queryUpdate = $"UPDATE tab_wallets SET balance=balance+{summa} WHERE wallet_id={walletId}";
                var res = connection.Execute(queryUpdate);
                return (res != 0, operation!);
            }
        }
    }
}
