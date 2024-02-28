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
    public class GroupRole : BaseEntity
    {
        public string? RoleName { get; set; }
        public Guid GroupID { get; set; }
        public bool AllowToAdd { get; set; }
        public bool AllowToRemove { get; set; }
        public bool AllowToMute { get; set; }
        public bool AllowToUnMute { get; set;}

        public virtual GroupChat? GroupChat { get; set; }
        public virtual IEnumerable<GroupMember>? GroupMembers { get; set; }
    }

    public class GroupRoleConfig : IEntityTypeConfiguration<GroupRole>
    {
        public void Configure(EntityTypeBuilder<GroupRole> builder)
        {
            builder.Property(x => x.RoleName).IsRequired()
                .HasMaxLength(25);
            builder.Property(x => x.GroupID).IsRequired();
        }
    }
}
