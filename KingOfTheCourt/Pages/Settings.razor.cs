using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingOfTheCourt.Data;

namespace KingOfTheCourt.Pages
{
    public partial class Settings
    {
        public List<PlayerModel> Players { get; set; }
        public List<TeamModel> Teams { get; set; }
        public PlayerModel SelectedPlayer { get; set; }
        public TeamModel SelectedTeam { get; set; }

        protected override void OnInitialized()
        {
            Players = new List<PlayerModel>();
            Teams = new List<TeamModel>();
        }

        public void CreateTeam()
        {
            Teams.Add(new TeamModel()
            {
                Name = "New Team"
            });
        }

        public void DeleteTeam()
        {
            if (SelectedTeam != null)
            {
                Teams.Remove(SelectedTeam);
            }
        }

        public void CreatePlayer()
        {
            Players.Add(new PlayerModel()
            {
                Name = "New Player"
            });
        }

        public void DeletePlayer()
        {
            if (SelectedPlayer != null)
            {
                Players.Remove(SelectedPlayer);
            }
        }

        public void SelectPlayer(PlayerModel Player)
        {
            SelectedPlayer = Player;
        }

        public void SelectTeam(TeamModel Team)
        {
            SelectedTeam = Team;
        }
    }
}
