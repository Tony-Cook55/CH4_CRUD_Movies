using Microsoft.EntityFrameworkCore;

namespace MovieProject.Models
{
    public class MovieContextModel           : DbContext // ADD : DbContext to allow certain call ins below to work
    {
        /*< This is our Model Class >*/
        // This is a List of <Movies> that will come from the database
        // DbSet<MovieModel> Movies is a property that represents the collection of all Movie Objects
        public DbSet<MovieModel> Movies { get; set; } = null!;
        // ASDASDASdasd   Movies being called in our MovieController To get the database items


        // This is used to make a table and database info for Genres
        public DbSet<GenreModel> Genres { get; set; } = null!;




        public MovieContextModel(DbContextOptions<MovieContextModel> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<GenreModel>().HasData(
                new GenreModel() { GenreModelId = "D", Name = "Drama" },
                new GenreModel() { GenreModelId = "C", Name = "Comedy" },
                new GenreModel() { GenreModelId = "A", Name = "Action" },
                new GenreModel() { GenreModelId = "H", Name = "Horror" },
                new GenreModel() { GenreModelId = "M", Name = "Musical" },
                new GenreModel() { GenreModelId = "R", Name = "RomCom" },
                new GenreModel() { GenreModelId = "S", Name = "SciFi" }
            );



            modelBuilder.Entity<MovieModel>().HasData(
                new MovieModel() { MovieModelId = 1, Name = "The Godfather", Year = 1972, Rating = 5, GenreModelId="D"},
                new MovieModel() { MovieModelId = 2, Name = "John Wick", Year = 2011, Rating = 4, GenreModelId = "A" },
                new MovieModel() { MovieModelId = 3, Name = "The Irishman", Year = 2020, Rating = 5, GenreModelId = "D" }
            );

        }


    }
}
