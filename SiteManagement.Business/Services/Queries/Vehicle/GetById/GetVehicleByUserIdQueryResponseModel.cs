namespace SiteManagement.Business.Services.Queries.Vehicle.GetById
{
    public class GetVehicleByUserIdQueryResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
