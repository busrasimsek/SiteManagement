namespace SiteManagement.Business.Services.Queries.Resident.GetResidentById
{
    public class GetResidentByIdQueryResponseModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public bool? Sex { get; set; }
        public int HomeId { get; set; }
    }
}
