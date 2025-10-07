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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {

        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Ignore(x => x.id);

            builder.Property(b=> b.CreatedAt)
                .HasColumnName("BookingDate")
                .HasDefaultValueSql("GETDATE()");
            builder.HasOne(x=>x.Session)
                .WithMany(s=>s.SessionMembers)
                .HasForeignKey(x=>x.SessionId);

            builder.HasOne(x=>x.Member)
                .WithMany(m=>m.MemberSessions)
                .HasForeignKey(x=>x.MemberId);

            builder.HasKey(b => new { b.MemberId, b.SessionId });


        }
    }
}

