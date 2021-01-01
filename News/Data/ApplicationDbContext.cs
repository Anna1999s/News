using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.Models;
using News.ViewModels;

namespace News.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {            
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<NewsModel> News { get; set; }
        public DbSet<NewsCategory> NewsCategory { get; set; }        

    }
}
