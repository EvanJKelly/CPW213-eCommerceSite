using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.data
{
    /// <summary>
    /// The database context class for
    /// the video game store
    /// </summary>
    public class GameContext : DbContext 
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
            
        }

        //Add a DbSet<T> for each entity you want to 
        // keep track of in the database
        public DbSet<VideoGame> videoGames { get; set; }

        
    }
}
