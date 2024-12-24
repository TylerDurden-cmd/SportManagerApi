using Microsoft.AspNetCore.Mvc;
using ApiProject_Joachim_Adomako.Services;
using ApiProject_Joachim_Adomako.Models;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ApiProject_Joachim_Adomako.Controllers;

[Route("api/[controller]")]
public class MatchController : ControllerBase
{
    private readonly IMatchService _MatchService;

    public MatchController(IMatchService matchService)
    {
        _MatchService = matchService;
    }

    [HttpPost]
    public async Task<ActionResult<Match>> CreateMatch(Match match)
    {
        await _MatchService.CreateMatch(match);

        return CreatedAtAction(nameof(CreateMatch), new { id = match.Id });
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Match>> GetMatch(int id)
    {
        var match = await _MatchService.GetMatch(id);
        if (match == null)
        {
            return NotFound();
        }
        return Ok(match);
    }

    [HttpGet]
    public async Task<ActionResult<List<Match>>> GetAllMatches()
    {
        var allMatch = await _MatchService.GetAllMatches();
        if (allMatch == null)
        {
            return NotFound();
        }
        return Ok(allMatch);
    }

    [HttpGet("{id}/image")]

    public async Task<ActionResult<string>> GetImageMatch(int id)
    {
        var imageMatch = await _MatchService.GetImageMatch(id);
        return Ok(imageMatch);
    }
    
    [HttpDelete("{id}/delete")]

    public async Task<ActionResult<List<Match>>> DeleteMatch(int id)
    {
        await _MatchService.DeleteMatch(id);
        var allMatches = await _MatchService.GetAllMatches();
        if(allMatches == null)
        {
            return NotFound();
        }

        return Ok(allMatches);
    }


    [HttpPut("{id}/update")]
    public async Task<ActionResult<Match>> UpdateMatch([FromRoute]int id,[FromBody] Match updatedMatch)
    {
        await _MatchService.UpdateMatch(id,updatedMatch);
        var allMatches = await _MatchService.GetAllMatches();
        if (allMatches == null)
        {
            return NotFound();
        }

        return Ok(allMatches);
        
    }

}