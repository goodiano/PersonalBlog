using GoodianoBlog.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);           
            builder.Property(p => p.Email).IsRequired().HasMaxLength(150); 
            builder.Property(p => p.PhonNumber).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.RePassword).IsRequired();
            builder.Property(p => p.Password).HasAnnotation("MinLength", 10);
            builder.Property(p => p.RePassword).HasAnnotation("MinLength", 10);
        }
    }
}
