namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс  Категория перации
    /// </summary>
    public class Category
    {
        /// <summary>
        /// идентификатор категории оперции
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// имя категории
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// тип  категории (0 - расход, 1 - приход)
        /// </summary>
        public bool Type { get; set; }
    }
}
