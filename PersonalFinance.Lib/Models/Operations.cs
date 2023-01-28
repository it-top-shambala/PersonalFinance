namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// класс Запись операции
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// идентификатор записи
        /// </summary>
        public int IdOperations { get; set; }

        /// <summary>
        /// идентификатор кошелька
        /// </summary>
        public int IdWallet { get; set; }

        /// <summary>
        /// время проведения операции
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// идентификатор категории операции
        /// </summary>
        public string? IdCategory { get; set; }

        /// <summary>
        /// сумма операции
        /// </summary>
        public double Summa { get; set; }
    }
}
