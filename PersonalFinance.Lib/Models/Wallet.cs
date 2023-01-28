namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс Кошелек
    /// </summary>
    public class Wallets
    {
        /// <summary>
        ///  IdWallet - идентификатор кошелька
        /// </summary>
        public int IdWallet { get; set; }

        /// <summary>
        ///  Name - имя кошелька
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// IdCurrency - идентификатор категории операции
        /// </summary>
        public int IdCurrency { get; set; }

        /// <summary>
        /// Balance - количество средств в кошельке
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
