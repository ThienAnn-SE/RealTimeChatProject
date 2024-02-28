﻿using API.Services;
using MainData;
using MainData.Repositories;

namespace RealTimeChatProjectAPI.Services
{
    public interface IAddFriendRequestInterface : IBaseService
    {

    }
    public class AddFriendRequestService : BaseService, IAddFriendRequestInterface
    {
        public AddFriendRequestService(MainUnitOfWork mainUnitOfWork, IHttpContextAccessor httpContextAccessor, IMapperRepository mapperRepository) : base(mainUnitOfWork, httpContextAccessor, mapperRepository)
        {
        }
    }
}
