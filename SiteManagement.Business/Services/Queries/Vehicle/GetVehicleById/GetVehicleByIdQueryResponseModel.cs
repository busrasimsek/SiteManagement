namespace SiteManagement.Business.Services.Queries.Vehicle.GetVehicleById
{
    public class GetVehicleByIdQueryResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
