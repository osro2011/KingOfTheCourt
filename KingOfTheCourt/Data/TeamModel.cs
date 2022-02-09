using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingOfTheCourt.Data
{
    public class TeamModel
    {
        public List<PlayerModel> Players { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public int Winstreak { get; set; }
    }
}
