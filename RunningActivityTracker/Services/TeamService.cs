using System.Collections.Generic;
using System.Linq;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Repositories;

namespace RunningActivityTracker.Services
{
    public class TeamService : ITeamService
    {
        private ITeamRepository _repository;

        private IUserRepository _userRepository;

        public TeamService(ITeamRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        public void CreateTeam(TeamEntity team)
        {
            _repository.CreateTeam(team);
        }

        public void AddMember(string memberName)
        {
            UserEntity user = _userRepository.FindUserByName(memberName);
            TeamEntity team = _repository.GetAll().FirstOrDefault(team => team.Admin != null);
            _repository.AddTeamMember(team, user);
        }

        public IEnumerable<TeamEntity> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
