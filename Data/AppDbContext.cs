
using Combine_Day_Sixteen_N_tier_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Combine_Day_Sixteen_N_tier_API.Data
{

    //The DbContext is the connection to our database
    public class AppDbContext : DbContext
    {
        //This is our constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }




        //Here we set our tables
        //E



        public DbSet<Supply> supplies {get;set;}
    }
}