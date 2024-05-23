using FiorelloAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<FooterSocials> Socials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);

            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDeleted);

            modelBuilder.Entity<Expert>().HasQueryFilter(m => !m.SoftDeleted);

            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);

            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);

            modelBuilder.Entity<Blog>().HasData(
        new Blog
        {
            Id = 1,
            Title = "Title1",
            Description = "Reshadin Blogu",
            Image = "blog-feature-img-1.jpg",
            CreateDate = DateTime.Now,
        },

        new Blog
        {
            Id = 2,
            Title = "Title2",
            Description = "Ilqarin Blogu",
            Image = "blog-feature-img-3.jpg",
            CreateDate = DateTime.Now,
        },

        new Blog
        {
            Id = 3,
            Title = "Title3",
            Description = "Hacixanin Blogu",
            Image = "blog-feature-img-4.jpg",
            CreateDate = DateTime.Now,
        }
);

            modelBuilder.Entity<Setting>().HasData(
new Setting
{
    Id = 1,
    Key = "HeaderLogo",
    Value = "logo.png",
    SoftDeleted = false,
    CreateDate = DateTime.Now,
},

new Setting
{
    Id = 2,
    Key = "Phone",
    Value = "12345",
    SoftDeleted = false,
    CreateDate = DateTime.Now,
},

new Setting
{
    Id = 3,
    Key = "Address",
    Value = "Ehmedli",
    SoftDeleted = false,
    CreateDate = DateTime.Now,
}
);

            modelBuilder.Entity<Expert>().HasData(
new Expert
{
    Id = 1,
    Title = "CRYSTAL BROOKS",
    Role = "Florist",
    Image = "h3-team-img-1.png",
    CreateDate = DateTime.Now,
},

new Expert
{
    Id = 2,
    Title = "SHIRLEY HARRIS",
    Role = "Manager",
    Image = "h3-team-img-2.png",
    CreateDate = DateTime.Now,
},

new Expert
{
    Id = 3,
    Title = "BEVERLY CLARK",
    Role = "Florist",
    Image = "h3-team-img-3.png",
    CreateDate = DateTime.Now,
},

new Expert
{
    Id = 4,
    Title = "AMANDA WATKINS",
    Role = "Florist",
    Image = "h3-team-img-4.png",
    CreateDate = DateTime.Now,
}
);
        }
    }
}
