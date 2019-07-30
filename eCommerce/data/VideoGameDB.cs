using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.data
{
    /// <summary>
    /// DB Helper class for VIdeoGames  
    /// </summary>
    public static class VideoGameDB
    {

        /// <summary>
        /// Adds a VideoGame to the data store abd sets
        /// the ID value
        /// </summary>
        /// <param name="g">The game to be added</param>
        /// <param name="context">The DB context to use</param>
        public static async Task<VideoGame> AddAsync(VideoGame g, GameContext context)
        {
            await context.AddAsync(g);
            await context.SaveChangesAsync();
            return g;
        }
    }
}
