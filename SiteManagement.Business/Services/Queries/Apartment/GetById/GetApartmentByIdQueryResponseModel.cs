namespace SiteManagement.Business.Services.Queries.Apartment.GetById
{
    public class GetApartmentByIdQueryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Block { get; set; }
        public string? Address { get; set; }
        public string? No { get; set; }
        public int? FloorCount { get; set; }
        public int? ManagerId { get; set; }
    }
}
