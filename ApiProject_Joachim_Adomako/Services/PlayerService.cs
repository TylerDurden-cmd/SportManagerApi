using ApiProject_Joachim_Adomako.Models;

namespace ApiProject_Joachim_Adomako.Services
{
    public class PlayerService : IPlayerService
    {
        private static readonly List<Player> AllPlayers = new();

        public Task CreatePlayer(Player player)
        {
            AllPlayers.Add(player);
            return Task.CompletedTask;
        }

        public Task<Player> GetPlayer(int id)
        {
            var player = AllPlayers.Find((x) => x.Id == id);

            return Task.FromResult(player);
        }

        public Task<List<Player>> GetAllPlayers()
        {
            return Task.FromResult(AllPlayers);
        }

        public Task<string> GetImagePlayer(int id)
        {
            var player = AllPlayers.Find((x) => x.Id == id);
            return Task.FromResult(player.Image);
        }

        public Task DeletePlayer(int id)
        {
            //delete alle matches 
            var player = AllPlayers.Find((x) => x.Id == id);

            AllPlayers.Remove(player);

            return Task.CompletedTask;
        }

        public Task UpdatePlayer(int id, Player updatePlayer)
        {
            var oldPlayer = AllPlayers.Find((x) => x.Id == id);

            if (id != updatePlayer.Id)
            {
                return Task.FromException(new ArgumentException($"The ID ${oldPlayer.Id} of the updated player: {oldPlayer.Name} does not match the provided ID ${updatePlayer.Id}."));
            }

            if (oldPlayer != null)
            {
                oldPlayer.Id = updatePlayer.Id;
                oldPlayer.Name = updatePlayer.Name;
                oldPlayer.Team_id = updatePlayer.Team_id;
                oldPlayer.Image = updatePlayer.Image;
            }

            return Task.CompletedTask;
        }
    }
}
