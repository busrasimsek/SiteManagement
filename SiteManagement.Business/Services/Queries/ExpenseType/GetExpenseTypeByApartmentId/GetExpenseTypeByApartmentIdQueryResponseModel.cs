namespace SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeByApartmentId
{
    public class GetExpenseTypeByApartmentIdQueryResponseModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public int ApartmentId { get; set; }
    }
}
