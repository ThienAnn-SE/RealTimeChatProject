using AppCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainData.Entities
{
    public class GroupChat : BaseEntity
    {
        public string? Name { get; set; }
        public Guid OwnerID { get; set; }

        public virtual User? Owner { get; set; }
        public virtual IEnumerable<GroupMessage>? Messages { get; set; }
        public virtual IEnumerable<GroupMember>? Members { get; set; }
        public virtual IEnumerable<GroupRole>? Roles { get; set; }
    }

    public class GroupChatConfig : IEntityTypeConfiguration<GroupChat>
    {
        public void Configure(EntityTypeBuilder<GroupChat> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.OwnerID).IsRequired();

            builder.HasMany(e => e.Members)
                .WithOne(e => e.GroupChat)
                .HasForeignKey(e => e.MemberID);

            builder.HasMany(e => e.Messages)
                .WithOne(e => e.GroupChat)
                .HasForeignKey(e => e.GroupID);

            builder.HasMany(e => e.Roles)
                .WithOne(e => e.GroupChat)
                .HasForeignKey(e => e.GroupID);

            builder.HasOne(e => e.Owner)
                .WithMany(e => e.OwnGroupChats)
                .HasForeignKey(e => e.OwnerID);
        }
    }
}
