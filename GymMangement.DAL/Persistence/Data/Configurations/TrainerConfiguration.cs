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
    public class TrainerConfiguration : GymUserConfigurations<Trainer> ,IEntityTypeConfiguration<Trainer>
    {
        public new void  Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(m => m.CreatedAt)
                 .HasColumnName("HireDate")
                 .HasDefaultValueSql("GETDATE()");
            base.Configure(builder);
        }
    }
}
