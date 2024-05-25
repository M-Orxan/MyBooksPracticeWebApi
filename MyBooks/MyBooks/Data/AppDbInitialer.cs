using MyBooks.Data.Models;
using System.Threading;

namespace MyBooks.Data
{
    public class AppDbInitialer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context=serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "1st Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now


                    },

                    new Book()
                    {


                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead=false,
                        
                       
                        Genre = "Biography",
                        Author = "2nd Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
