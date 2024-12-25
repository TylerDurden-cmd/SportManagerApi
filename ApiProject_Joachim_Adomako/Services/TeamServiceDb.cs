using ApiProject_Joachim_Adomako.Data;
using ApiProject_Joachim_Adomako.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiProject_Joachim_Adomako.Services
{
    public class TeamServiceDb : ITeamService
    {
        private readonly SportDbContext _contextSport;

        public TeamServiceDb(SportDbContext context)
        {
            _contextSport = context;
        }

        public async Task CreateTeam(Team team)
        {
            _contextSport.Teams.Add(team);
            await _contextSport.SaveChangesAsync();
        }

        public async Task<Team> GetTeam(int id)
        {
            return await _contextSport.Teams
                .Include((c) => c.players)
                .Include((x) => x.AwayMatches)
                .Include((x) => x.HomeMatches)
                .FirstOrDefaultAsync((x) => x.Id == id);
        }

        public async Task<List<Team>> GetAllTeams()
        {
            return await _contextSport.Teams
                .Include(c => c.players)
                .Include((x) => x.AwayMatches)
                .Include((x) => x.HomeMatches)
                .ToListAsync();
        }

        public async Task<string> GetImageTeam(int id)
        {
            var Team = await _contextSport.Teams
                .FirstOrDefaultAsync((x) => x.Id == id);
            if(Team == null)
            {
                throw new ArgumentNullException(nameof(Team),"Team not found");
            }
            return Team.Image;
        }

        public async Task DeleteTeam(int id)
        {
            //delete alle matches 
            var team = await _contextSport.Teams
                .Include((x) => x.players)
                .Include((x) => x.AwayMatches)
                .Include((x) => x.HomeMatches)
                .FirstOrDefaultAsync((x) => x.Id == id);
            if (team != null)
            {
                _contextSport.Teams.Remove(team);
                await _contextSport.SaveChangesAsync();
            }

        }

        public async Task UpdateTeam(int id, Team updateTeam)
        {
            var oldTeam = await _contextSport.Teams
                .Include((x) => x.players)
                .Include((x) => x.AwayMatches)
                .Include((x) => x.HomeMatches)
                .FirstOrDefaultAsync((x) => x.Id == id);

            if (oldTeam == null)
            {
                throw new ArgumentNullException(nameof(oldTeam), "Team not found.");
            }

            if (id != updateTeam.Id)
            {
                throw new ArgumentException($"The ID ${oldTeam.Id} of the updated Team: {oldTeam.Name} does not match the provided ID ${updateTeam.Id}.");
            }

            oldTeam.Id = updateTeam.Id;
            oldTeam.Name = updateTeam.Name;
            oldTeam.City = updateTeam.City;
            oldTeam.Coach = updateTeam.Coach;
            oldTeam.Sport = updateTeam.Sport;
            oldTeam.Image = updateTeam.Image;

            _contextSport.Entry(oldTeam).State = EntityState.Modified;
            await _contextSport.SaveChangesAsync();
        }
    }
}
