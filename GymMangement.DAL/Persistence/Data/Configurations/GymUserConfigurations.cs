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
    public class GymUserConfigurations : IEntityTypeConfiguration<GymUser>
    {
        public void Configure(EntityTypeBuilder<GymUser> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Email)
             .HasColumnType("varchar")
             .HasMaxLength(100);

            builder.Property(x => x.Phone)
             .HasColumnType("varchar")
             .HasMaxLength(11);

            builder.OwnsOne(x => x.Adress, adress =>
            {
                adress.Property(a => a.City)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .HasColumnName("City");
                adress.Property(a => a.Street)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .HasColumnName("Street"); ;
                adress.Property(a => a.BuldingNo)
                .HasColumnName("BuldingNo");
               
            });

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.ToTable(x =>
            {
                x.HasCheckConstraint("CK_GymUser_Email_ValidFormat", "[Email] LIKE '_%@_%._%'");
                x.HasCheckConstraint("CK_GymUser_Phone_ValidFormat", "[Phone] LIKE '01%' AND [Phone] NOT LIKE '%[^0-9]%'");

            });




        }


    }
}
