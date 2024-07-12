using Microsoft.EntityFrameworkCore;
using QuestionnaireBack.Models;

namespace QuestionnaireBack.Service
{

    public class UsersService : IUsers
    {
        private readonly IConfiguration configuration;
        public UsersService(IConfiguration configuration) {
            this.configuration = configuration;
        }
        private readonly Context context;
        public UsersService(Context context)
        {
            this.context = context;
        }
        async public Task<Users> Create(Users dto)
        {
            Users user = new Users();

            user.Name = dto.Name;
            user.Role = dto.Role;
            user.Group = dto.Group;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }

        async public Task<List<Users>?> FindAll()
        {
            if (context.Users == null)
            {
                return null;
            }
            return await context.Users.ToListAsync();
        }

        async public Task<Users?> FindOneByName(string name)
        {
            if (context.Users == null) return null;

            var user = await (context.Users?.FirstOrDefaultAsync(e => e.Name == name));
            return user;
        }


        public async Task<Users?> Remove(string name)
        {
            if (context.Users == null)
            {
                return null;
            }

            var user = await context.Users.SingleOrDefaultAsync(x => x.Name == name);

            if (user == null)
            {
                return null;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        private bool UserExists(string name)
        {
            return (context.Users?.Any(e => e.Name == name)).GetValueOrDefault();
        }
    }
}
