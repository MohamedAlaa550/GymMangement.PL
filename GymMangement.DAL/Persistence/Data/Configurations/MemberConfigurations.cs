using GymMangement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Data.Configurations
{
    public class MemberConfigurations :GymUserConfigurations<Member> ,IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.CreatedAt)
                 .HasColumnName("JoinDate")
                 .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.HealthRecord)
                .WithOne()
                .HasForeignKey<HealthRecord>(x => x.id);
            base.Configure(builder);
        }
    }
}
