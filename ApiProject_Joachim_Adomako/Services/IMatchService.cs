using ApiProject_Joachim_Adomako.Models;

namespace ApiProject_Joachim_Adomako.Services
{
    public interface IMatchService
    {
        Task CreateMatch(Match match);
        Task DeleteMatch(int id);
        Task<List<Match>> GetAllMatches();
        Task<string> GetImageMatch(int id);
        Task<Match> GetMatch(int id);
        Task UpdateMatch(int id, Match updatedMatch);
    }
}