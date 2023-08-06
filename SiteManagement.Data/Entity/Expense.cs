using SiteManagement.Core.Entity;

namespace SiteManagement.Data.Entity
{
    public class Expense : BaseEntity
    {
        public int ExpenseTypeId { get; set; }
        public float Amount { get; set; }
        public bool PaymentStatus { get; set; }
        public int HomeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
        public virtual Home Home { get; set; }
    }
}
