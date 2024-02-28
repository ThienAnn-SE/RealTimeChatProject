using API.Services;
using AppCore.Extensions;
using AppCore.Models;
using MainData;
using MainData.Entities;
using MainData.Repositories;
using RealTimeChatProjectAPI.Dtos;

namespace RealTimeChatProjectAPI.Services
{
    public interface IMessageService : IBaseService
    {
        Task<ApiResponse> SendMessage(SendMessageDto message);
        Task<ApiResponses<MessageDto>> GetUserReceivedMessage(Guid senderId);
    }
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(MainUnitOfWork mainUnitOfWork, IHttpContextAccessor httpContextAccessor, IMapperRepository mapperRepository) : base(mainUnitOfWork, httpContextAccessor, mapperRepository)
        {
        }

        public async Task<ApiResponses<MessageDto>> GetUserReceivedMessage(Guid senderId)
        {
            var messages = await MainUnitOfWork.MessageRepository.FindAsync<MessageDto>(
                new System.Linq.Expressions.Expression<Func<Message, bool>>[]
                {
                    x => x.SenderID == senderId,
                    x => x.ReceiverID == AccountId
                }, "CreatedAt desc");
            messages = await _mapperRepository.MapCreator(messages);
            return ApiResponses<MessageDto>.Success(messages);
        }

        public async Task<ApiResponse> SendMessage(SendMessageDto message)
        {
            var sendMessage = message.ProjectTo<SendMessageDto, Message>();
            sendMessage.Id = Guid.Empty;
            sendMessage.SenderID = AccountId.Value;

            if (!await MainUnitOfWork.MessageRepository.InsertAsync(sendMessage, AccountId, CurrentDate))
            {
                throw new ApiException("Can't create send message", StatusCode.SERVER_ERROR);
            }
            return ApiResponse.Success(); 
        }
    }
}
