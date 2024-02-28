using MainData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainData
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<AddFriendRequest> AddFriendRequests { get; set; }
        public DbSet<Token> Tokens { set; get; }
        public DbSet<FriendList> Friends { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupRole> GroupRoles { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddFriendRequestConfig());
            modelBuilder.ApplyConfiguration(new TokenConfig());
            modelBuilder.ApplyConfiguration(new FriendListConfig());
            modelBuilder.ApplyConfiguration(new GroupChatConfig());
            modelBuilder.ApplyConfiguration(new GroupMemberConfig());
            modelBuilder.ApplyConfiguration(new GroupRoleConfig());
            modelBuilder.ApplyConfiguration(new MessageConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
