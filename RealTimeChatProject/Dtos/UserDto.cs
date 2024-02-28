using AppCore.Models;
using MainData.Entities;
using System.ComponentModel.DataAnnotations;

namespace RealTimeChatProjectAPI.Dtos
{
    public class UserDto : BaseDto
    {
        [Display(Name = "FullName", Order = 3)]
        public string? FullName { get; set; }

        [Display(Name = "Status", Order = 7)]
        public UserStatus Status { get; set; }
        [Display(Name = "Email", Order = 8)]
        public string? Email { get; set; }
        [Display(Name = "PhoneNumber", Order = 9)]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Username", Order = 11)]
        public string? Username { get; set; }
    }

    public class UserUpdate
    {
        public string? Fullname { get; set; }
        public UserStatus? Status { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
