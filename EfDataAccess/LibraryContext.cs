using Domain;
using EfDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DEUS_EX_MACHINA\SQLEXPRESS;Initial Catalog=library;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookGenreConfiguration());
            modelBuilder.ApplyConfiguration(new BookReservationConfiguration());
            modelBuilder.ApplyConfiguration(new BookGenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WriterConfiguration());

            //DATA SEED

            //modelBuilder.Entity<Writer>().HasData(new Writer
            //{
            //    Id = 1,
            //    CreatedAt = '2019-06-10 19:36:06.6553986',
            //    IsDeleted = false,
            //    Name = "Ivo Andric"
            //});

            //modelBuilder.Entity<Writer>().HasData(new Writer
            //{
            //    Id = 2,
            //    CreatedAt = 2019-06-10 19:36:06.6553986,
            //    IsDeleted = false,
            //    Name = "Pisac Piscic"
            //});

            //modelBuilder.Entity<Role>().HasData(new
            //{
            //    Id = 1,
            //    CreatedAt = "2019-06-10 19:36:06.6553986",
            //    IsDeleted = false,
            //    Name = ""
            //});

            //modelBuilder.Entity<Book>().HasData(new
            //{
            //    Id = 1,
            //    CreatedAt = "2019-06-10 19:36:06.6553986",
            //    IsDeleted = false,
            //    Title = "Na drini cuprija",
            //    WriterId = 1,
            //    Description = "Delo koje je Ivu Andricu donelo Nobela.",
            //    AvailableCount = 2,
            //    Count = 2
            //});
            //modelBuilder.Entity<Book>().HasData(new
            //{
            //    Id = 2,
            //    CreatedAt = "2019-06-10 19:36:06.6553986",
            //    IsDeleted = false,
            //    Title = "Ljubav u doba kokaina",
            //    WriterId = 2,
            //    Description = "Iskreno i nije nesto ali ako ste tinejdzer proci ce",
            //    AvailableCount = 100,
            //    Count = 99
            //});



        }
    }
}
