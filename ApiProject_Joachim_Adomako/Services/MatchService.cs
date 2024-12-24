using ApiProject_Joachim_Adomako.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace ApiProject_Joachim_Adomako.Services
{
    public class MatchService : IMatchService
    {
        private static readonly List<Match> AllMatch = new();

        public Task CreateMatch(Match match)
        {
            AllMatch.Add(match);
            return Task.CompletedTask;
        }

        public Task<Match> GetMatch(int id)
        {
            var match = AllMatch.Find((x) => x.Id == id);

            return Task.FromResult(match);
        }

        public Task<List<Match>> GetAllMatches()
        {
            return Task.FromResult(AllMatch);
        }

        public Task<string> GetImageMatch(int id)
        {
            var match = AllMatch.Find((x) => x.Id == id);
            return Task.FromResult(match.Image);
        }

        public Task DeleteMatch(int id)
        {
            var match = AllMatch.Find((x) => x.Id == id);

            AllMatch.Remove(match);

            return Task.CompletedTask;
        }

        public Task UpdateMatch(int id, Match updatedMatch)
        {
            var oldMatch = AllMatch.Find((x) => x.Id == id);

            if (id != updatedMatch.Id)
            {
                return Task.FromException(new ArgumentException("The ID of the updated match does not match the provided ID."));
            }

            if (oldMatch != null)
            {
                oldMatch.Id = updatedMatch.Id;
                oldMatch.Image = updatedMatch.Image;
                oldMatch.Location = updatedMatch.Location;
                oldMatch.Outcome = updatedMatch.Outcome;
                oldMatch.Team1_id = updatedMatch.Team1_id;
                oldMatch.Team2_id = updatedMatch.Team2_id;
            }

            return Task.CompletedTask;
        }
    }
}
