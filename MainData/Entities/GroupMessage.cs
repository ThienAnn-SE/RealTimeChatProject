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
    public class GroupMessage : BaseEntity
    {
        public Guid SenderID { get; set; }
        public Guid GroupID { get; set; }
        public string? Text { get; set; }

        public virtual GroupChat? GroupChat { get; set; }
        public virtual User? Sender { get; set; }
    }

    public class GroupMessageConfig : IEntityTypeConfiguration<GroupMessage>
    {
        public void Configure(EntityTypeBuilder<GroupMessage> builder)
        {
            builder.Property(x => x.SenderID).IsRequired();
            builder.Property(x => x.GroupID).IsRequired();
            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(e => e.GroupChat)
                .WithMany(e => e.Messages)
                .HasForeignKey(e => e.GroupID);

            builder.HasOne(e => e.Sender)
                .WithMany(e => e.GroupMessages)
                .HasForeignKey(e => e.SenderID);
        }
    }
}
