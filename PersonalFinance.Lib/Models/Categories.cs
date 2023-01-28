namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс  Категории пераций
    /// </summary>
    public class Categories
    {
        /// <summary>
        ///  Id - идентификатор категории оперции
        /// </summary>
        public int IdCategory { get; set; }

        /// <summary>
        /// Name - имя категории
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// TypeOperation - тип  категории (0 - расход, 1 - приход)
        /// </summary>
        public bool Type { get; set; }
    }
}
