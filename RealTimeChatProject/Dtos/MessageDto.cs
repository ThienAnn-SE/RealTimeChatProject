using AppCore.Models;

namespace RealTimeChatProjectAPI.Dtos
{
    public class MessageDto : BaseDto
    {
        public string? Text { get; set; }
    }

    public class SendMessageDto : BaseDto
    {
        public Guid ReceiverID { get; set; }
        public string? Text { get; set; }
    }
}
