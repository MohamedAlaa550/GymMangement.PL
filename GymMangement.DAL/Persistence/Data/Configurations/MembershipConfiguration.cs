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
    public class MembershipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.Ignore(x => x.id);

            builder.Property(b => b.CreatedAt)
                .HasColumnName("StartDate")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Member)
                .WithMany(m => m.MemberPlans)
                .HasForeignKey(x => x.MemberId);

            builder.HasOne(x => x.Plan)
                .WithMany(p => p.PlanMembers)
                .HasForeignKey(x => x.PlanId);

           builder.HasKey(x=> new {x.MemberId, x.PlanId });
        }
    }
}
