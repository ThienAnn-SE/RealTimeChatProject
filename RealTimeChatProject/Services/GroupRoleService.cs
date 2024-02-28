using API.Services;
using MainData;
using MainData.Repositories;

namespace RealTimeChatProjectAPI.Services
{
    public interface IGroupRoleService : IBaseService { }
    public class GroupRoleService : BaseService, IGroupRoleService
    {
        public GroupRoleService(MainUnitOfWork mainUnitOfWork, IHttpContextAccessor httpContextAccessor, IMapperRepository mapperRepository) : base(mainUnitOfWork, httpContextAccessor, mapperRepository)
        {
        }
    }
}
