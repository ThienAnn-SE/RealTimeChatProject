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
    public class FriendList : BaseEntity
    {
        public Guid OwnerID { get; set; }
        public Guid FriendID { get; set; }

        public virtual User? Owner { get; set; }
        public virtual User? OwnerFriend { get; set; }
    }

    public class FriendListConfig : IEntityTypeConfiguration<FriendList>
    {
        public void Configure(EntityTypeBuilder<FriendList> builder)
        {
            builder.Property(x => x.OwnerID).IsRequired();
            builder.Property(x => x.FriendID).IsRequired();

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.FriendList)
                .HasForeignKey(x => x.OwnerID);

            builder.HasOne(x => x.OwnerFriend)
                    .WithMany(x => x.FriendTo)
                    .HasForeignKey(x => x.FriendID);
        }
    }
}
