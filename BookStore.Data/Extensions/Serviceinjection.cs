using BookStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Extensions
{
   public static class Serviceinjection
    {
        public static void AddProjectModules(this IServiceCollection services)
        {
            services.AddDbContext<BookStoreDBContext>(context => { context.UseInMemoryDatabase("BookStoreDB"); });
            //services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
