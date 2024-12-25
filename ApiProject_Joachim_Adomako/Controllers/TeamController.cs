using Microsoft.AspNetCore.Mvc;
using ApiProject_Joachim_Adomako.Services;
using ApiProject_Joachim_Adomako.Models;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace ApiProject_Joachim_Adomako.Controllers;

[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _TeamService;

    public TeamController(ITeamService teamService)
    {
        _TeamService = teamService;
    }

    [HttpPost]
    public async Task<ActionResult<Team>> CreateTeam(Team team)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _TeamService.CreateTeam(team);
        return CreatedAtAction(nameof(CreateTeam), new { id = team.Id });
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Team>> GetTeam(int id)
    {
        var team = await _TeamService.GetTeam(id);
        if (team == null)
        {
            return NotFound();
        }
        return Ok(team);
    }

    [HttpGet]
    public async Task<ActionResult<List<Team>>> GetAllTeam()
    {
        var allTeams = await _TeamService.GetAllTeams();
        if (allTeams == null)
        {
            return NotFound();
        }
        return Ok(allTeams);
    }

    [HttpGet("{id}/image")]

    public async Task<ActionResult<string>> GetImageTeam(int id)
    {
        var imageTeam = await _TeamService.GetImageTeam(id);
        return Ok(imageTeam);
    }

    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<List<Team>>> DeleteTeam(int id)
    {
        await _TeamService.DeleteTeam(id);
        var allTeams = await _TeamService.GetAllTeams();
        if (allTeams == null)
        {
            return NotFound();
        }

        return Ok(allTeams);
    }


    [HttpPut("{id}/update")]
    public async Task<ActionResult<Team>> UpdateTeam([FromRoute] int id, [FromBody] Team updateTeam)
    {
        await _TeamService.UpdateTeam(id,updateTeam);
        var allTeams = await _TeamService.GetAllTeams();
        if (allTeams == null)
        {
            return NotFound();
        }

        return Ok(allTeams);

    }

}