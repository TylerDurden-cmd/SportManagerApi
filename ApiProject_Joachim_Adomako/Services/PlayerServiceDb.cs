using ApiProject_Joachim_Adomako.Data;
using ApiProject_Joachim_Adomako.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ApiProject_Joachim_Adomako.Services
{
    public class PlayerServiceDb : IPlayerService
    {
        private readonly SportDbContext _contextSport;

        public PlayerServiceDb(SportDbContext context)
        {
            _contextSport = context;
        }

        public async Task CreatePlayer(Player player)
        {   
            _contextSport.players.Add(player);
             await _contextSport.SaveChangesAsync();
        }

        public async Task<Player> GetPlayer(int id)
        {
            return await _contextSport.players
                .Include((x) => x.Team)
                .FirstOrDefaultAsync((x) => x.Id == id);
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _contextSport.players
                .Include((x) => x.Team)
                .ToListAsync();
        }

        public async Task<string> GetImagePlayer(int id)
        {
            var player = await _contextSport.players
                .FirstOrDefaultAsync((x) => x.Id == id);
            if(player == null)
            {
                throw new ArgumentNullException(nameof(player), "player not found");
            }
            return player.Image;
        }

        public async Task DeletePlayer(int id)
        {
            //delete alle matches 
            var player = await _contextSport.players
                .Include((x) => x.Team)
                .FirstOrDefaultAsync((x) => x.Id == id);
            if(player != null)
            {
                _contextSport.players.Remove(player);
                await _contextSport.SaveChangesAsync();
            }

        }

        public async Task UpdatePlayer(int id, Player updatePlayer)
        {
            var oldPlayer = await _contextSport.players
                .Include((x) => x.Team)
                .FirstOrDefaultAsync((x) => x.Id == id);

            if (id != updatePlayer.Id)
            {
                throw new ArgumentException($"The ID ${oldPlayer.Id} of the updated player: {oldPlayer.Name} does not match the provided ID ${updatePlayer.Id}.");
            }

            if (id != updatePlayer.Id)
            {
                throw new ArgumentException($"The ID ${updatePlayer.Id} of the updated Team: {updatePlayer.Name} does not match the provided ID ${updatePlayer.Id}.");
            }
           
            oldPlayer.Id = updatePlayer.Id;
            oldPlayer.Name = updatePlayer.Name;
            oldPlayer.Age = updatePlayer.Age;
            oldPlayer.Team_id = updatePlayer.Team_id;
            oldPlayer.Image = updatePlayer.Image;

            _contextSport.Entry(oldPlayer).State = EntityState.Modified;
            await _contextSport.SaveChangesAsync();
        }
    }
}
