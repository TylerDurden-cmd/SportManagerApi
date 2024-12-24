using Microsoft.AspNetCore.Mvc;
using ApiProject_Joachim_Adomako.Services;
using ApiProject_Joachim_Adomako.Models;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace ApiProject_Joachim_Adomako.Controllers;

[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _PlayerService;

    public PlayerController(IPlayerService playerService)
    {
        _PlayerService = playerService;
    }

    [HttpPost]
    public async Task<ActionResult<Player>> CreatePlayer(Player player)
    {
        await _PlayerService.CreatePlayer(player);

        return CreatedAtAction(nameof(CreatePlayer), new { id = player.Id });
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Player>> GetPlayer(int id)
    {
        var player = await _PlayerService.GetPlayer(id);
        if (player == null)
        {
            return NotFound();
        }
        return Ok(player);
    }

    [HttpGet]
    public async Task<ActionResult<List<Player>>> GetAllPlayers()
    {
        var allPlayers = await _PlayerService.GetAllPlayers();
        if(allPlayers == null)
        {
            return NotFound();
        }
        return Ok(allPlayers);
    }

    [HttpGet("{id}/image")]
    public async Task<ActionResult<string>> GetImagePlayer(int id)
    {
        var imagePlayer = await _PlayerService.GetImagePlayer(id);
        return Ok(imagePlayer);
    }

    [HttpDelete("{id}/delete")]
    public async Task<ActionResult<List<Player>>> DeletePlayer(int id)
    {
        await _PlayerService.DeletePlayer(id);
        var allPlayers = await _PlayerService.GetAllPlayers();
        if (allPlayers == null)
        {
            return NotFound();
        }

        return Ok(allPlayers);
    }


    [HttpPut("{id}/update")]
    public async Task<ActionResult<Player>> UpdatePlayer([FromRoute]int id,[FromBody] Player updatePlayer)
    {
        await _PlayerService.UpdatePlayer(id, updatePlayer);
        var allPlayers = await _PlayerService.GetAllPlayers();
        if (allPlayers== null)
        {
            return NotFound();
        }

        return Ok(allPlayers);

    }



}

