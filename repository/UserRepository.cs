using Entytess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDatabaseContext _dbContext;
        public UserRepository(StoreDatabaseContext dbContext)
        {
            _dbContext = dbContext;

        }


        public async Task<User> getUserByUserNameAndPassword(string userName, string password)
        {
            return await _dbContext.Users.Where(user => user.Email == userName && user.Password == password).FirstOrDefaultAsync();
        }


        public async Task<User> CreateNewUser(User user)
        {
          await  _dbContext.AddAsync(user);
          await  _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task Put(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;
            _dbContext.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();
        }
    }
}