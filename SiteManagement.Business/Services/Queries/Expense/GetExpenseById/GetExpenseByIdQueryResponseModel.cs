namespace SiteManagement.Business.Services.Queries.Expense.GetExpenseById
{
    public class GetExpenseByIdQueryResponseModel
    {
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public float Amount { get; set; }
        public bool PaymentStatus { get; set; }
        public int HomeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
    }
}
