using API.Controllers;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatProjectAPI.Dtos;
using RealTimeChatProjectAPI.Services;

namespace RealTimeChatProjectAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ApiResponse<UserDto>> GetUserDetail(Guid id)
        {
            return await _userService.GetUserDetail(id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ApiResponse> UpdateInformation(Guid id, UserUpdate userUpdate)
        {
            return await _userService.UpdateInformation(id, userUpdate);
        }
    }
}
