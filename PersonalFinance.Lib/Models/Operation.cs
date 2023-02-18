using Dapper.Contrib.Extensions;

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
        [Computed]
        public DateTime? Date { get; set; }

        private string? _date;
        public string? OperationDate
        {
            get => _date;
            set
            {
                _date = value;
                if (_date != null)
                {
                    Date = DateTime.ParseExact(_date, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }

            }
        }

        /// <summary>S
        /// имя категории операции
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// сумма операции
        /// </summary>
        public double Sum { get; set; }
    }
}
