using API.Services;
using MainData;
using MainData.Repositories;

namespace RealTimeChatProjectAPI.Services
{
    public interface IGroupMessageService : IBaseService { }
    public class GroupMessageService : BaseService, IGroupMessageService
    {
        public GroupMessageService(MainUnitOfWork mainUnitOfWork, IHttpContextAccessor httpContextAccessor, IMapperRepository mapperRepository) : base(mainUnitOfWork, httpContextAccessor, mapperRepository)
        {
        }
    }
}
