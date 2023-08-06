namespace SiteManagement.Business.Services.Queries.User.GetUserById
{
    public class GetUserByIdQueryResponseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
    }
}
