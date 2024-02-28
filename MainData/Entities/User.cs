using AppCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainData.Entities
{
    public class User : BaseEntity
    {
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public UserStatus Status { get; set; }
        public DateTime DateOfBith { get; set; }
        public bool Gender { get; set; }
        public string? AvatarPath { get; set; }
        public string? Salt { get; set; }

        public virtual IEnumerable<Message>? Messages { get; set; }
        public virtual IEnumerable<FriendList>? FriendList { get; set; }
        public virtual IEnumerable<FriendList>? FriendTo { get; set; }
        public virtual IEnumerable<AddFriendRequest>? AddFriendSendRequests { get; set; }
        public virtual IEnumerable<AddFriendRequest>? AddFriendReceiveRequests { get; set; }
        public virtual IEnumerable<GroupChat>? OwnGroupChats { get; set; }
        public virtual IEnumerable<GroupMember>? GroupMembers { get; set; }

        public virtual IEnumerable<GroupMessage>? GroupMessages { get; set; }
    }

    public enum UserStatus
    {
        Active = 1, InActive = 2, Blocked = 3
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.DateOfBith).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.AvatarPath).IsRequired(false);
            builder.Property(x => x.Salt).IsRequired();
        }
    }
}
