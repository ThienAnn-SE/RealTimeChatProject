using AppCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainData.Entities
{
    public class GroupMember : BaseEntity
    {
        public Guid GroupID { get; set; }
        public Guid MemberID { get; set; }
        public Guid GroupRoleID { get; set; }
        public virtual GroupChat? GroupChat { get; set; }
        public virtual User? Member { get; set; }
        public virtual GroupRole? Role { get; set; }
    }

    public class GroupMemberConfig : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.Property(x => x.GroupID).IsRequired();
            builder.Property(x => x.MemberID).IsRequired();
            builder.Property(x => x.GroupRoleID).IsRequired();

            builder.HasOne(e => e.Member)
                .WithMany(e => e.GroupMembers)
                .HasForeignKey(e => e.MemberID);

            builder.HasOne(e => e.Role)
                .WithMany(e => e.GroupMembers)
                .HasForeignKey(e => e.GroupRoleID);
        }
    }
}
