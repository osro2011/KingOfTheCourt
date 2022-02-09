using KingOfTheCourt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingOfTheCourt.Services
{
    public  static class Database
    {
        public static List<TeamModel> GetTeams()
        {
            return new List<TeamModel>
            {
                new TeamModel
                {
                    Name = "Team 1",
                    Players = new List<PlayerModel>
                    {
                        new PlayerModel
                        {
                            Name = "test"
                        },
                        new PlayerModel
                        {
                            Name = "test2"
                        }
                    }
                },
                new TeamModel
                {
                    Name = "Team 2",
                    Players = new List<PlayerModel>
                    {
                        new PlayerModel
                        {
                            Name = "test3"
                        },
                        new PlayerModel
                        {
                            Name = "test4"
                        }
                    }
                },
                new TeamModel
                {
                    Name = "Team 3",
                    Players = new List<PlayerModel>
                    {
                        new PlayerModel
                        {
                            Name = "test5"
                        },
                        new PlayerModel
                        {
                            Name = "test6"
                        }
                    }
                },
                new TeamModel
                {
                    Name = "Team 4",
                    Players = new List<PlayerModel>
                    {
                        new PlayerModel
                        {
                            Name = "test7"
                        },
                        new PlayerModel
                        {
                            Name = "test8"
                        }
                    }
                },
                new TeamModel
                {
                    Name = "Team 5",
                    Players = new List<PlayerModel>
                    {
                        new PlayerModel
                        {
                            Name = "test9"
                        },
                        new PlayerModel
                        {
                            Name = "test10"
                        }
                    }
                }
            };
        }
    }
}
