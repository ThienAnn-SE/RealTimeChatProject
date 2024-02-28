using AppCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainData.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public string? Text { get; set; }

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
    }

    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.SenderID).IsRequired();
            builder.Property(x => x.ReceiverID).IsRequired();
            builder.Property(x => x.Text).IsRequired().HasMaxLength(255);

            builder.HasOne(x =>x.Sender)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.SenderID);

            builder.HasOne(x => x.Receiver)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.ReceiverID);
        }
    }
}
