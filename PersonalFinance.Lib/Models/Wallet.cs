namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс Кошелек
    /// </summary>
    public class Wallet
    {
        /// <summary>
        ///  Id - идентификатор кошелька
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Name - имя кошелька
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Currency - объект валюты
        /// </summary>
        public Currency? Currency { get; set; }

        /// <summary>
        /// Balance - количество средств в кошельке
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Метод проведения операции с кошельком
        /// </summary>
        /// <param name="sum">sum - сумма операции
        /// положительное значение - сумма прихода
        /// отрицательное значение - сумма расхода</param>
        public bool WalletOperation(double sum)
        {
            if ((Balance += sum) >= 0)
            {
                return true;
            }

            Balance -= sum;
            return false;
        }
    }
}
