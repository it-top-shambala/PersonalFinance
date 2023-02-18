namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс Валюта
    /// </summary>
    public class Currency
    {
        /// <summary>
        ///  идентификатор валюты
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// имя валюты
        /// </summary>
        public string? CurrencyName { get; set; }

        /// <summary>
        ///  код валюты
        /// </summary>
        public string? CurrencyCode { get; set; }
    }
}
