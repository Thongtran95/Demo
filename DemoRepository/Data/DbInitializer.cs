using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DemoRepository.Data.Model
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();


                // Add Customers
                var justin = new Customer { Name = "Justin Noon" };

                var willie = new Customer { Name = "Willie Parodi" };

                var leoma = new Customer { Name = "Leoma  Gosse" };

                context.Customer.Add(justin);
                context.Customer.Add(willie);
                context.Customer.Add(leoma);

                // Add Author
                var authorDeMarco = new Author
                {
                    Name = "M J DeMarco",
                    Books = new List<Book>()
                    {
                        new Book { Title = "The Millionaire Fastlane" },
                        new Book { Title = "Unscripted" }
                    }
                };

                var authorCardone = new Author
                {
                    Name = "Grant Cardone",
                    Books = new List<Book>()
                    {
                        new Book { Title = "The 10X Rule"},
                        new Book { Title = "If You're Not First, You're Last"},
                        new Book { Title = "Sell To Survive"}
                    }
                };

                context.Author.Add(authorDeMarco);
                context.Author.Add(authorCardone);

                context.SaveChanges();
            }
        }
        
    }
}