namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// класс  Операция
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// идентификатор операции
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// идентификатор кошелька
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        /// время проведения операции
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// имя категории операции
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// сумма операции
        /// </summary>
        public double Summa { get; set; }
    }
}
