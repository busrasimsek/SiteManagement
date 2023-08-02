namespace SiteManagement.Business.Services.Queries.Home.GetAll
{
    public class GetAllHomeQueryResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Floor { get; set; }
        public string No { get; set; }
        public string HomeType { get; set; }
        public bool? Status { get; set; }
        public int ApartmentId { get; set; }
        public bool? IsTenant { get; set; }
    }
}
