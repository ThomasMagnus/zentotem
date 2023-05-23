using System.ComponentModel.DataAnnotations;

namespace ZenTotem
{
    /// <summary>
    /// Модель пользователей
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal SalaryPerHour { get; set; }
    }
}
