namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс Кошелек
    /// </summary>
    public class Wallet
    {
        /// <summary>
        ///  идентификатор кошелька
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        ///  имя кошелька
        /// </summary>
        public string? WalletName { get; set; }

        /// <summary>
        /// имя категории операции
        /// </summary>
        public string? CurrencyName { get; set; }

        /// <summary>
        /// количество средств в кошельке
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Метод проведения операции с кошельком
        /// </summary>
        /// <param name="summa">summa - сумма операции</param>
        public void WalletOperation(double summa)
        {
            Balance += summa;
        }
    }
}
