using ApiProject_Joachim_Adomako.Data;
using ApiProject_Joachim_Adomako.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiProject_Joachim_Adomako.Services
{
    public class TeamService : ITeamService
    {
        private static readonly List<Team> AllTeams = new();

        public Task CreateTeam(Team team)
        {
            AllTeams.Add(team);
            return Task.CompletedTask;
        }

        public Task<Team> GetTeam(int id)
        {
            var team = AllTeams.FirstOrDefault((x) => x.Id == id);
            return Task.FromResult(team);
        }

        public Task<List<Team>> GetAllTeams()
        {
            return Task.FromResult(AllTeams);
        }

        public Task<string> GetImageTeam(int id)
        {
            var Team = AllTeams.FirstOrDefault((x) => x.Id == id);
            return Task.FromResult(Team.Image);
        }

        public Task DeleteTeam(int id)
        {
            //delete alle matches 
            var team = AllTeams.FirstOrDefault((x) => x.Id == id);
            if (team != null)
            {
                AllTeams.Remove(team);
            }

            return Task.CompletedTask;

        }

        public Task UpdateTeam(int id, Team updateTeam)
        {
            var oldTeam = AllTeams.FirstOrDefault((x) => x.Id == id);

            if (oldTeam == null)
            {
                return Task.FromException(new ArgumentNullException(nameof(oldTeam), "Team not found."));
            }

            if (id != updateTeam.Id)
            {
                return Task.FromException(new ArgumentException($"The ID ${oldTeam.Id} of the updated Team: {oldTeam.Name} does not match the provided ID ${updateTeam.Id}."));
            }

            oldTeam.Id = updateTeam.Id;
            oldTeam.Name = updateTeam.Name;
            oldTeam.City = updateTeam.City;
            oldTeam.Coach = updateTeam.Coach;
            oldTeam.Sport = updateTeam.Sport;
            oldTeam.Image = updateTeam.Image;

            return Task.CompletedTask;
        }
    }
}
