using System.Collections.Generic;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Services;

namespace RunningActivityTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Database _context;

        public UserRepository(Database database)
        {
            _context = database;
        }
        public UserEntity FindUserByName(string userName)
        {
            return _context.FindUserByName(userName);
        }

        public void CreateUser(UserEntity user)
        {
            _context.CreateUser(user);
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _context.GetAllUsers();
        }

        public void Clear()
        {
            _context.ClearUsers();
        }
    }
}
