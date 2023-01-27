namespace PersonalFinance.Lib.Models
{
    /// <summary>
    /// Класс  Операция (расход и приход)
    /// </summary>
    public class Operation
    {
        /// <summary>
        ///  Id - идентификатор оперции
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name - имя операции
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// TypeOperation - тип  операции (0 - расход, 1 - приход)
        /// </summary>
        public bool TypeOperation { get; set; }
    }
}
