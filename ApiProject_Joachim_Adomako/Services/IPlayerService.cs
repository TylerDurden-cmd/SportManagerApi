using ApiProject_Joachim_Adomako.Models;

namespace ApiProject_Joachim_Adomako.Services
{
    public interface IPlayerService
    {
        Task CreatePlayer(Player player);
        Task DeletePlayer(int id);
        Task<List<Player>> GetAllPlayers();
        Task<string> GetImagePlayer(int id);
        Task<Player> GetPlayer(int id);
        Task UpdatePlayer(int id, Player updatePlayer);
    }
}