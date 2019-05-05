using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator11.Model
{
    public class MoviesDbSeeder
    {
        public static void Initialize(MoviesDbContext context)
        {
            context.Database.EnsureCreated();
            // Look for any Movies.

            if (context.Movies.Any())
            {
                return; //DB has been seeded
            }

            context.Movies.AddRange(
                new Movie
                {
                    Title = "AAA",
                    Runtime = 100,
                    Rating = 5.5,
                    Storyline = "AAAAA AAAA AAAAA"
                },
                 new Movie
                 {
                     Title = "BBB",
                     Runtime = 200,
                     Rating = 6.5,
                     Storyline = "BBBB BBBB BBBBB"
                 });
            context.SaveChanges();
        }
    }
}
