using System.Collections.Generic;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Services
{
    public interface ITeamService
    {
        void CreateTeam(TeamEntity team);
        void AddMember(string memberName);
        IEnumerable<TeamEntity> GetAll();
    }
}
