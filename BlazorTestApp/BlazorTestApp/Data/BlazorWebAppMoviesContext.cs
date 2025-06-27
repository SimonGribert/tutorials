using BlazorTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestApp.Data
{
    public class BlazorWebAppMoviesContext(DbContextOptions<BlazorWebAppMoviesContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
