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
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasOne(x => x.Trainer)
                 .WithMany(t => t.Sessions)
                 .HasForeignKey(x => x.TrainerId);

            builder.HasOne(x => x.Category)
                .WithMany(c => c.Sessions)
                .HasForeignKey(x => x.CategoryId);

            builder.ToTable(x =>
            {
                x.HasCheckConstraint("CK_Session_Capacity", "[Capacity] Between 1 And 25");
                x.HasCheckConstraint("CK_Session_EndDate", "[EndDate] > [StartDate]");


            });
        }
    }
}
