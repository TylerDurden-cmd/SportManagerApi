using ApiProject_Joachim_Adomako.Data;
using ApiProject_Joachim_Adomako.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace ApiProject_Joachim_Adomako.Services
{
    public class MatchServiceDb : IMatchService
    {
        private readonly SportDbContext _contextSport;

        public MatchServiceDb(SportDbContext context)
        {
            _contextSport = context;
        }

        public async Task CreateMatch(Match match)
        {
            _contextSport.Matches.Add(match);
            await _contextSport.SaveChangesAsync();
        }

        public async Task<Match> GetMatch(int id)
        {
            return await _contextSport.Matches
                .Include((x) => x.Team1)
                .Include((x) => x.Team2)
                .FirstOrDefaultAsync((x) => x.Id == id);
        }

        public async Task<List<Match>> GetAllMatches()
        {
            return await _contextSport.Matches
                .Include((x) => x.Team1)
                .Include((x) => x.Team2)
                .ToListAsync();
        }

        public async Task<string> GetImageMatch(int id)
        {
            var match = await _contextSport.Matches
                .FirstOrDefaultAsync((x) => x.Id == id);
            if(match == null)
            {
                throw new ArgumentNullException(nameof(match), "Match not found");
            }
            return match.Image;
        }

        public async Task DeleteMatch(int id)
        {
            var match = await _contextSport.Matches
                .Include((x) => x.Team1)
                .Include((x) => x.Team2)
                .FirstOrDefaultAsync((x) => x.Id == id);
            if(match != null)
            {
                _contextSport.Matches.Remove(match);
                await _contextSport.SaveChangesAsync();
            }

        }

        public async Task UpdateMatch(int id, Match updatedMatch)
        {
            var oldMatch = await _contextSport.Matches
                .Include((x) => x.Team1)
                .Include((x) => x.Team2)
                .FirstOrDefaultAsync((x) => x.Id == id);

            if (oldMatch == null)
            {
                throw new ArgumentNullException(nameof(oldMatch), "Team not found.");
            }

            if (id != updatedMatch.Id)
            {
                throw new ArgumentException("The ID of the updated match does not match the provided ID.");
            }

            oldMatch.Id = updatedMatch.Id;
            oldMatch.Image = updatedMatch.Image;
            oldMatch.Location = updatedMatch.Location;
            oldMatch.Outcome = updatedMatch.Outcome;
            oldMatch.Team1_id = updatedMatch.Team1_id;
            oldMatch.Team2_id = updatedMatch.Team2_id;

            _contextSport.Entry(oldMatch).State = EntityState.Modified;
            await _contextSport.SaveChangesAsync();
        }
    }
}
