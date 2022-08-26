using System.Collections.Generic;
using System.Linq;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Services
{
    public class Database
    {
        private List<TeamEntity> _teamEntity;

        private List<UserEntity> _userEntity;

        public Database()
        {
            _teamEntity = new();
            _userEntity = new();
            _teamEntity.Add(new TeamEntity("Cowboys",new List<UserEntity>(), new UserEntity()));
            _userEntity.Add(new UserEntity()
            {
                Email = "prescott@cowboys.hu",
                Password = "ohyeah",
                Roles = new[] {"TeamAdmin"},
                Username = "chocolateVanillaLightning"
            });
            _userEntity.Add(new UserEntity()
            {
                Email = "elliott@cowboys.hu",
                Password = "ohno",
                Roles = new[] { "User" },
                Username = "feedZeke"
            });
        }

        public UserEntity FindUserByName(string username)
        {
            return _userEntity.FirstOrDefault(user => user.Username == username);
        }

        public void CreateUser(UserEntity user)
        {
            _userEntity.Add(user);
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _userEntity;
        }

        public void ClearUsers()
        {
            _userEntity.Clear();
        }

        public TeamEntity FindTeamByAdmin(string username)
        {
            return _teamEntity.FirstOrDefault(team => team.Admin.Username == username);
        }

        public TeamEntity FindTeamByMember(string username)
        {
            return _teamEntity.FirstOrDefault(team => team.Members.Contains(FindUserByName(username)));
        }

        public void CreateTeam(TeamEntity team)
        {
            _teamEntity.Add(team);
        }

        public void ClearTeams()
        {
            _teamEntity.Clear();
        }

        public void AddTeamMember(TeamEntity team, UserEntity member)
        {
            _teamEntity.FirstOrDefault(team).Members.Add(member);
        }

        public IEnumerable<TeamEntity> GetAllTeams()
        {
            return _teamEntity;
        }
    }
}
