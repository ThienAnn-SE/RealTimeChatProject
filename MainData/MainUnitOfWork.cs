using AppCore.Data;
using MainData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainData
{
    public class MainUnitOfWork : IDisposable
    {
        private readonly DatabaseContext databaseContext;

        public MainUnitOfWork(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public BaseRepository<AddFriendRequest> AddFriendRequestRepository => new(databaseContext);
        public BaseRepository<FriendList> FriendListRepository => new(databaseContext);
        public BaseRepository<GroupChat> GroupChatRepository => new(databaseContext);
        public BaseRepository<GroupMember> GroupMemberRepository => new(databaseContext);
        public BaseRepository<GroupMessage> GroupMessageRepository => new(databaseContext);
        public BaseRepository<GroupRole> GroupRoleRepository => new(databaseContext);
        public BaseRepository<Message> MessageRepository => new(databaseContext);
        public BaseRepository<User> UserRepository => new(databaseContext);
        public BaseRepository<Token> TokenRepository => new(databaseContext);
        public void Dispose()
        {
        }
    }
}
