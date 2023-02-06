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
        public int CurrancyId { get; set; }

        /// <summary>
        /// имя валюты
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///  код валюты
        /// </summary>
        public string Code { get; set; }
    }
}
