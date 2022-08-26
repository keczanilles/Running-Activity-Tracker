using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Services;

namespace RunningActivityTracker.Controllers
{

    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [Authorize(Roles = "User")]
        [HttpPost("/team")]
        public ActionResult CreateTeam([FromBody] TeamEntity team)
        {
            _teamService.CreateTeam(team);
            return Ok();
        }

        [Authorize(Roles = "TeamAdmin")]
        [HttpPut("/team/members")]
        public ActionResult AddMember([FromBody] string memberName)
        {
            _teamService.AddMember(memberName);
            return Ok();
        }
    }
}
