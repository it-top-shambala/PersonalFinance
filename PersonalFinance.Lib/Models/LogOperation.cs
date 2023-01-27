namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// класс Запись операции
    /// </summary>
    public class LogOperation
    {
        /// <summary>
        /// идентификатор записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// идентификатор кошелька
        /// </summary>
        public int IdWallet { get; set; }

        /// <summary>
        /// время проведения операции
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// идентификатор операции
        /// </summary>
        public string? IdOperation { get; set; }

        /// <summary>
        /// сумма операции
        /// </summary>
        public double Sum { get; set; }
    }
}
