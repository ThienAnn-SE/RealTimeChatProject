using AppCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainData.Entities
{
    public class AddFriendRequest : BaseEntity
    {
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public Status Status { get; set; }

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
    }

    public enum Status
    {
        Waitting = 0, Accepted = 1, Canceled = 2
    }

    public class AddFriendRequestConfig : IEntityTypeConfiguration<AddFriendRequest>
    {
        public void Configure(EntityTypeBuilder<AddFriendRequest> builder)
        {
            builder.Property(x => x.SenderID).IsRequired();
            builder.Property(x => x.ReceiverID).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.Sender)
                .WithMany(x => x.AddFriendSendRequests)
                .HasForeignKey(x => x.SenderID);

            builder.HasOne(x => x.Receiver)
                .WithMany(x => x.AddFriendReceiveRequests)
                .HasForeignKey(x => x.ReceiverID);
        }
    }
}
