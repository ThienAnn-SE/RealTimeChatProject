using API.Services;
using AppCore.Models;
using MainData;
using MainData.Entities;
using MainData.Repositories;
using RealTimeChatProjectAPI.Dtos;
using System.Linq.Expressions;

namespace RealTimeChatProjectAPI.Services
{
    public interface IUserService : IBaseService
    {
        Task<ApiResponse<UserDto>> GetUserDetail(Guid id);
        Task<ApiResponse> UpdateInformation(Guid id, UserUpdate userUpdate);

    }

    public class UserService : BaseService, IUserService
    {
        public UserService(MainUnitOfWork mainUnitOfWork, IHttpContextAccessor httpContextAccessor, IMapperRepository mapperRepository) : base(mainUnitOfWork, httpContextAccessor, mapperRepository)
        {
        }

        public async Task<ApiResponse<UserDto>> GetUserDetail(Guid id)
        {
            var user = await MainUnitOfWork.UserRepository.FindOneAsync<UserDto>(new Expression<Func<User, bool>>[]
            {
                x => !x.DeletedAt.HasValue,
                x => x.Id == id
            });

            if (user == null)
                throw new ApiException("Not found this user", StatusCode.NOT_FOUND);

            user = await _mapperRepository.MapCreator(user);

            return ApiResponse<UserDto>.Success(user);
        }

        public async Task<ApiResponse> UpdateInformation(Guid id, UserUpdate userUpdate)
        {
            var user = await MainUnitOfWork.UserRepository.FindOneAsync(new Expression<Func<User, bool>>[]
            {
                x => !x.DeletedAt.HasValue,
                x => x.Id == id
            });

            if (user == null)
                throw new ApiException("Not found this user", StatusCode.NOT_FOUND);

            if (user.Id != AccountId)
            {
                var checkRole = await MainUnitOfWork.UserRepository.FindOneAsync(new Expression<Func<User, bool>>[]
                {
                    x => !x.DeletedAt.HasValue,
                    x => x.Id == AccountId
                });

                if (checkRole == null)
                    throw new ApiException("Can't not update information of this user", StatusCode.BAD_REQUEST);
            }

            user.FullName = userUpdate.Fullname ?? user.FullName;
            user.Status = userUpdate.Status ?? user.Status;
            user.Email = userUpdate.Email ?? user.Email;
            if (userUpdate.Status != null)
            {
                user.Status = userUpdate.Status.Value;
            }

            user.PhoneNumber = userUpdate.PhoneNumber ?? user.PhoneNumber;

            if (!await MainUnitOfWork.UserRepository.UpdateAsync(user, AccountId, CurrentDate))
                throw new ApiException("Updated fail", StatusCode.SERVER_ERROR);

            return ApiResponse.Success();
        }
    }
}
