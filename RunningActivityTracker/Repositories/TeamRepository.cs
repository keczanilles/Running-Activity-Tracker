using System.Collections.Generic;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Services;

namespace RunningActivityTracker.Repositories
{
    public class  TeamRepository : ITeamRepository
    {
        private Database _context;

        public TeamRepository(Database database)
        {
            _context = database;
        }
        public TeamEntity FindTeamByAdmin(string userName)
        {
            return _context.FindTeamByAdmin(userName);
        }

        public TeamEntity FindTeamByMember(string userName)
        {
            return _context.FindTeamByMember(userName);
        }

        public void CreateTeam(TeamEntity team)
        {
            _context.CreateTeam(team);
        }

        public void Clear()
        {
            _context.ClearTeams();
        }

        public void AddTeamMember(TeamEntity team, UserEntity member)
        {
            _context.AddTeamMember(team, member);
        }

        public IEnumerable<TeamEntity> GetAll()
        {
            return _context.GetAllTeams();
        }
    }
}
