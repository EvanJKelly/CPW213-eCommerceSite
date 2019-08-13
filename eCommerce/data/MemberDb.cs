using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.data
{
    public static class MemberDb
    {
        /// <summary>
        /// Adds a member to the database. Returns the member with their MemberId populated
        /// </summary>
        /// <param name="context">The database context to be used</param>
        /// <param name="m"></param>
        /// <returns></returns>
        public async static Task<Member> Add(GameContext context, Member m)
        {
           context.Members.Add(m);
           await context.SaveChangesAsync();
           return m;
        }
        public async static Task<bool> IsLoginValid(LoginViewModel model, GameContext context)
        {
            return await  
                (from m in context.Members
                 where (m.UserName == model.UsernameOrEmail || m.EmailAddress == model.UsernameOrEmail) &&
                 model.Password == model.Password
                 select m).AnyAsync();
        }
    }
}
