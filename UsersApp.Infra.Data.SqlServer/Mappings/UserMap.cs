using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Models;

namespace UsersApp.Infra.Data.SqlServer.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).HasMaxLength(150);

            builder.Property(u => u.Email).HasMaxLength(50);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Password).HasMaxLength(100);

            builder.Property(u => u.CreatedAt);

            builder.Property(u => u.Status);

            builder.Property(u => u.RoleId);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
