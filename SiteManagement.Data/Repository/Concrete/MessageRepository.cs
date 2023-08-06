using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class MessageRepository : Repository<Message, EfDbContext>, IMessageRepository
    {
        public MessageRepository(EfDbContext context) : base(context)
        {
        }
    }
}
