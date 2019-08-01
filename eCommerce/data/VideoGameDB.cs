using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Retrieves all games sorted in alphabetical order
        /// by title
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<VideoGame>> GetAllGames(GameContext context)
        {
            //LINQ Query Syntax
            //List<VideoGame> games =
                   //await (from vidGame in context.videoGames
                        //orderby vidGame.Title ascending
                        //select vidGame).ToListAsync();

            //LINQ Method Syntax
            List<VideoGame> games = await context.videoGames
                                                 .OrderBy(g => g.Title)
                                                  .ToListAsync();

            return games;
        }

       public static async Task<VideoGame> UpdateGame(VideoGame g, GameContext context)
        {
             context.Update(g);
             await context.SaveChangesAsync();
            return g;
        }

        public static async Task DeleteById(int id, GameContext context)
        {
            //Create videog ame object, with the id of the game
            //we want to remove from the database
            VideoGame g = new VideoGame()
            {
                Id = id
            };
            context.Entry(g).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a game with a specified Id. If no game is found null
        /// is returned
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async static Task<VideoGame> GetGameById(int id, GameContext context)
        {
            VideoGame g = await (from game in context.videoGames
                           where game.Id == id
                           select game).SingleOrDefaultAsync();
            return g;
        }
    }
}
