using GoodianoBlog.Application.Config;
using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.RoleList;
using GoodianoBlog.Domain.Entities.HomePage.HomePageImages;
using GoodianoBlog.Domain.Entities.HomePage.Sliders;
using GoodianoBlog.Domain.Entities.Posts;
using GoodianoBlog.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Persistance.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReplay> CommentReplays { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<HomePageImage> HomePageImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());

            ApplyQueryFilter(modelBuilder);
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsRemoved);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, RoleName = nameof(RoleItems.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, RoleName = nameof(RoleItems.Customer) });
        }
    }
}
