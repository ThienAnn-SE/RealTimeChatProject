using API.Services;
using MainData;
using MainData.Repositories;

namespace RealTimeChatProjectAPI.Services
{
    public interface IGroupChatService : IBaseService { }
    public class GroupChatService : BaseService, IGroupChatService
    {
        public GroupChatService(MainUnitOfWork mainUnitOfWork, IHttpContextAccessor httpContextAccessor, IMapperRepository mapperRepository) : base(mainUnitOfWork, httpContextAccessor, mapperRepository)
        {
        }
    }
}
