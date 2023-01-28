namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс Валюта
    /// </summary>
    public class Currencies
    {
        /// <summary>
        ///  IdCurrancy - идентификатор валюты
        /// </summary>
        public int IdCurrancy { get; set; }

        /// <summary>
        /// Name - имя валюты
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///  Code - код валюты
        /// </summary>
        public int Code { get; set; }
    }
}
