using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

    }

    public class MovieDBContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}