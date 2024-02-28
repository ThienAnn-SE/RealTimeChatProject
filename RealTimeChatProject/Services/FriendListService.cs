using API.Services;
using MainData;
using MainData.Repositories;

namespace RealTimeChatProjectAPI.Services
{
    public interface IFriendListService : IBaseService
    {

    }
    public class FriendListService : BaseService, IFriendListService
    {
        public FriendListService(MainUnitOfWork mainUnitOfWork, IHttpContextAccessor httpContextAccessor, IMapperRepository mapperRepository) : base(mainUnitOfWork, httpContextAccessor, mapperRepository)
        {
        }
    }
}
