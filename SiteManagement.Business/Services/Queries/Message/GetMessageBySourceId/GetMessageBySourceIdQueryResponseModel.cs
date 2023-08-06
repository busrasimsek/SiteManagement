namespace SiteManagement.Business.Services.Queries.Message.GetMessageBySourceId
{
    public class GetMessageBySourceIdQueryResponseModel
    {
        public int DestionationUserId { get; set; }
        public bool IsSeen { get; set; }
        public string Username { get; set; }
        public int NotSeenMessageCount { get; set; }
    }
}
