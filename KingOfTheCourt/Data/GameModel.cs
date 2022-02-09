using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingOfTheCourt.Data
{
    public class GameModel
    {
        public int TimeLeft { get; set; }
        public Queue<TeamModel> Queue { get; set; }
        public TeamModel King { get; set; }
        public TeamModel Challenger { get; set; }
        public int Stage { get; set; }
    }
}