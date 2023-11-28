using System;
using FiorelloBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBackend.Data
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


		public DbSet<Slider> Sliders { get; set; }

		public DbSet<SliderInfo> SliderInfos { get; set; }

		public DbSet<Blog> Blogs { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<Category> Categories { get; set; }

		public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<Instagram> Instagrams { get; set; }

		public DbSet<Subscribe> Subscribes { get; set; }

		public DbSet<Expert> Experts { get; set; }
		public DbSet<ValentineOpportunity> ValentineOpportunities { get; set; }
		public DbSet<ValentineOpportunityInfo> ValentineOpportunityInfos { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<CategoryArchive> CategoryArchives { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slider>().HasQueryFilter(m=>!m.SoftDeleted);
			modelBuilder.Entity<SliderInfo>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Expert>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Instagram>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<ProductImage>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Subscribe>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Testimonial>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<ValentineOpportunity>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<ValentineOpportunityInfo>().HasQueryFilter(m => !m.SoftDeleted);

            //modelBuilder.Entity<Category>().HasMany(m => m.Products).WithOne(m => m.Category)
            //    .HasForeignKey(m => m.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Product>().HasMany(m => m.Images).WithOne(m => m.Product)
            //   .HasForeignKey(m => m.ProductId)
            //   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Slider>().HasData(
				new Slider { Id = 1, Img = "h3-slider-background.jpg",Status=true, SoftDeleted = false },
				new Slider { Id = 2, Img = "h3-slider-background-2.jpg", Status = true, SoftDeleted = false },
				new Slider { Id = 3, Img = "h3-slider-background-3.jpg", Status = false, SoftDeleted = false }
			);


            modelBuilder.Entity<SliderInfo>().HasData(
            new SliderInfo { Id = 1,Title= "<h1>Send <span>flowers </span>  like</h1> <h1>you mean it</h1>",
		    Description= "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will make it special cursus a sit amet mauris.",
		    SignImg= "h2-sign-img.png", SoftDeleted = false }
           
             );



			modelBuilder.Entity<Blog>().HasData(
				new Blog { Id=  1,Title= "Flower Power",Description= "1Class aptent taciti sociosqu ad litora torquent per conubia nostra, per",Image= "blog-feature-img-1.jpg",SoftDeleted=false },
                new Blog { Id = 2, Title = "Local Florists", Description = "2Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", Image = "blog-feature-img-4.jpg", CreatedDate=new DateTime(2023,05,04), SoftDeleted = false },
                new Blog { Id = 3, Title = "Flower Beauty", Description = "3Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", Image = "blog-feature-img-3.jpg", CreatedDate = new DateTime(2023, 02, 02), SoftDeleted = false },
                new Blog { Id = 4, Title = "New Data", Description = "4Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", Image = "blog-feature-img-1.jpg", CreatedDate = new DateTime(2023, 02, 03), SoftDeleted = true }
            );

            modelBuilder.Entity<Expert>().HasData(
               new Expert { Id = 1, Image= "h3-team-img-1.png",Author= "CRYSTAL BROOKS",Position= "Florist", SoftDeleted = false },
               new Expert { Id = 2, Image = "h3-team-img-2.png", Author = "SHIRLEY HARRIS", Position = "Manager", SoftDeleted = false },
               new Expert { Id = 3, Image = "h3-team-img-4.png", Author = "AMANDA WATKINS", Position = "Florist", SoftDeleted = false },
               new Expert { Id = 4, Image = "h3-team-img-3.png", Author = "BEVERLY CLARK", Position = "Florist", SoftDeleted = false }

           );


            modelBuilder.Entity<Instagram>().HasData(
              new Instagram { Id = 1, Image = "instagram1.jpg", SoftDeleted = false },
              new Instagram { Id = 2, Image = "instagram2.jpg", SoftDeleted = false },
              new Instagram { Id = 3, Image = "instagram3.jpg", SoftDeleted = false },
              new Instagram { Id = 4, Image = "instagram4.jpg", SoftDeleted = false },
              new Instagram { Id = 5, Image = "instagram5.jpg", SoftDeleted = false },
              new Instagram { Id = 6, Image = "instagram6.jpg", SoftDeleted = false },
              new Instagram { Id = 7, Image = "instagram7.jpg", SoftDeleted = false },
              new Instagram { Id = 8, Image = "instagram8.jpg", SoftDeleted = false }
          );

            modelBuilder.Entity<Testimonial>().HasData(
             new Testimonial { Id = 1, Image = "testimonial-img-1.png", About= "Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus lingua.", Author= "Anna Barnes", Position= "Florist", SoftDeleted = false },
             new Testimonial { Id = 2, Image = "testimonial-img-2.png", About = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget.", Author = "Jasmine White", Position = "Florist", SoftDeleted = false }
         );


            modelBuilder.Entity<Subscribe>().HasData(
                new Subscribe { Id = 1, Image = "h3-background-img.jpg",Title= "Join The Colorful Bunch!", SoftDeleted = false }     
            );

            modelBuilder.Entity<ValentineOpportunity>().HasData(
               new ValentineOpportunity { Id = 2, VideoImage = "h3-video-img.jpg", VideoIcon= "fas fa-play fa-lg", Title = "<h1>Suprise Your <span>Valentine!</span> Let us arrange a smile.</h1>", Description= "Where flowers are our inspiration to create lasting memories. Whatever the occasion...", SoftDeleted = false }
           );



            modelBuilder.Entity<ValentineOpportunityInfo>().HasData(
              new ValentineOpportunityInfo { Id = 1,Icon= "h1-custom-icon.png", Name= "Hand picked just for you.", ValentineOpportunityId=2, SoftDeleted = false },
              new ValentineOpportunityInfo { Id = 2, Icon = "h1-custom-icon.png", Name = "Unique flower arrangements", ValentineOpportunityId = 2, SoftDeleted = false },
              new ValentineOpportunityInfo { Id = 3, Icon = "h1-custom-icon.png", Name = "Best way to say you care.", ValentineOpportunityId =2, SoftDeleted = false }
          );

            


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name= "POPULAR", SoftDeleted = false },
                new Category { Id = 2, Name = "WINTER", SoftDeleted = false },
                new Category { Id = 3, Name = "VARIOUS", SoftDeleted = false },
                new Category { Id = 4, Name = "EXOTIC", SoftDeleted = false },
                new Category { Id = 5, Name = "GREENS", SoftDeleted = false },
                new Category { Id = 6, Name = "CACTUSES", SoftDeleted = false }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Test1", Description = "Desc1", Price = 200, Count = 1, CategoryId = 6, SoftDeleted = false },
                new Product { Id = 2, Name = "Test2", Description = "Desc2", Price = 300, Count = 1, CategoryId = 4, SoftDeleted = false },
                new Product { Id = 3, Name = "Test3", Description = "Desc3", Price = 400, Count = 1, CategoryId = 3, SoftDeleted = false },
                new Product { Id = 4, Name = "Test4", Description = "Desc4", Price = 500, Count = 1, CategoryId = 1, SoftDeleted = false },
                new Product { Id = 5, Name = "Test5", Description = "Desc5", Price = 600, Count = 1, CategoryId = 2, SoftDeleted = false },
                new Product { Id = 6, Name = "Test6", Description = "Desc6", Price = 700, Count = 1, CategoryId = 2, SoftDeleted = false },
                new Product { Id = 7, Name = "Test7", Description = "Desc7", Price = 800, Count = 1, CategoryId = 4, SoftDeleted = false },
                new Product { Id = 8, Name = "Test8", Description = "Desc8", Price = 900, Count = 1, CategoryId = 5, SoftDeleted = false },
                new Product { Id = 9, Name = "Test9", Description = "Desc9", Price = 100, Count = 1, CategoryId = 5, SoftDeleted = false }
            );


            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 1, Image = "shop-14-img.jpg", IsMain = false, ProductId = 1, SoftDeleted = false },
                new ProductImage { Id = 2, Image = "shop-13-img.jpg", IsMain = true, ProductId = 1, SoftDeleted = false },
                new ProductImage { Id = 3, Image = "shop-12-img.jpg", IsMain = false, ProductId = 1, SoftDeleted = false },

                new ProductImage { Id = 4, Image = "shop-13-img.jpg", IsMain = false, ProductId = 2, SoftDeleted = false },
                new ProductImage { Id = 5, Image = "shop-14-img.jpg", IsMain = true, ProductId = 2, SoftDeleted = false },

                new ProductImage { Id = 6, Image = "shop-11-img.jpg", IsMain = false, ProductId = 3, SoftDeleted = false },
                new ProductImage { Id = 7, Image = "shop-10-img.jpg", IsMain = false, ProductId = 3, SoftDeleted = false },
                new ProductImage { Id = 8, Image = "shop-9-img.jpg", IsMain = true, ProductId = 3, SoftDeleted = false },

                new ProductImage { Id = 9, Image = "shop-11-img.jpg", IsMain = true, ProductId = 4, SoftDeleted = false },
                new ProductImage { Id = 10,Image = "shop-12-img.jpg", IsMain = false, ProductId = 4, SoftDeleted = false },

                new ProductImage { Id = 11,Image = "shop-10-img.jpg", IsMain = true, ProductId = 5, SoftDeleted = false },
                new ProductImage { Id = 12,Image = "shop-13-img.jpg", IsMain = false, ProductId = 5, SoftDeleted = false },

                new ProductImage { Id = 13,Image = "shop-12-img.jpg", IsMain = true, ProductId = 6, SoftDeleted = false },
                new ProductImage { Id = 14,Image = "shop-14-img.jpg", IsMain = false, ProductId = 6, SoftDeleted = false },

                new ProductImage { Id = 15,Image = "shop-8-img.jpg", IsMain = true, ProductId = 7, SoftDeleted = false },
                new ProductImage { Id = 16,Image = "shop-11-img.jpg", IsMain = false, ProductId = 7, SoftDeleted = false },
                new ProductImage { Id = 17,Image = "shop-9-img.jpg", IsMain = false, ProductId = 7, SoftDeleted = false },

                new ProductImage { Id = 18,Image = "shop-7-img.jpg", IsMain = true, ProductId = 8, SoftDeleted = false },
                new ProductImage { Id = 19,Image = "shop-10-img.jpg", IsMain = false, ProductId = 8, SoftDeleted = false },

                new ProductImage { Id = 20,Image = "shop-14-img.jpg", IsMain = true, ProductId = 9, SoftDeleted = false },
                new ProductImage { Id = 21,Image = "shop-8-img.jpg", IsMain = false, ProductId = 9, SoftDeleted = false }
            );

                modelBuilder.Entity<Setting>().HasData(
                new Setting {Id=1,Key="HeaderLogo",Value= "logo.png",SoftDeleted=false },
                new Setting { Id = 2, Key = "Address", Value = "Hazi Aslanov", SoftDeleted = false }
                );


        }
    }
}

