using ApiProject_Joachim_Adomako.Models;

namespace ApiProject_Joachim_Adomako.Services
{
    public interface ITeamService
    {
        Task CreateTeam(Team team);
        Task DeleteTeam(int id);
        Task<List<Team>> GetAllTeams();
        Task<string> GetImageTeam(int id);
        Task<Team> GetTeam(int id);
        Task UpdateTeam(int id, Team updateTeam);
    }
}