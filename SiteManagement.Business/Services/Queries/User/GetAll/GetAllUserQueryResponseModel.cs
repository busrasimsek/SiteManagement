namespace SiteManagement.Business.Services.Queries.User.GetAll
{
    public class GetAllUserQueryResponseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
    }
}
