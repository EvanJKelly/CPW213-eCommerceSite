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
        public static VideoGame Add(VideoGame g, GameContext context)
        {
            context.Add(g);
            context.SaveChanges();
            return g;
        }
    }
}
