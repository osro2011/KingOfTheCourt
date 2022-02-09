using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using KingOfTheCourt.Data;
using KingOfTheCourt.Services;

namespace KingOfTheCourt.Pages
{
    public partial class Game
    {
        public Timer Timer { get; set; }
        public GameModel CurrentGame { get; set; }
        public string TimerText { get; set; } = "00:00";

        protected override void OnInitialized()
        {
            CurrentGame = new GameModel();
            CurrentGame.Queue = new Queue<TeamModel>(Database.GetTeams());
            CurrentGame.King = CurrentGame.Queue.Dequeue();
            CurrentGame.Challenger = CurrentGame.Queue.Dequeue();
        }

        public void Start()
        {
            CurrentGame.TimeLeft = 900;
            CurrentGame.Stage = 1;

            SetTimer(1000);

            InvokeAsync(StateHasChanged);
        }

        public void SetTimer(int Time)
        {
            Timer = new Timer(Time);
            Timer.AutoReset = true;
            Timer.Elapsed += TimeElapsed;
            Timer.Enabled = true;
            Timer.Start();
        }

        public void TimeElapsed(Object source, ElapsedEventArgs e)
        {
            CurrentGame.TimeLeft--;
            int Minutes = CurrentGame.TimeLeft /60;
            string Seconds = (CurrentGame.TimeLeft %60).ToString();
            if (CurrentGame.TimeLeft %60 < 10)
            {
                Seconds = "0" + Seconds;
            }

            TimerText = String.Format("{0}:{1}", Minutes.ToString(), Seconds);
            if (CurrentGame.TimeLeft <= 0)
            {
                StageEnd();
            }

            InvokeAsync(StateHasChanged);
        }

        public void StageStart() { 
        }

        public void StageEnd()
        {
            CurrentGame.Stage++;

            // Sort queue and remove lowest scoring team
            CurrentGame.Queue.Enqueue(CurrentGame.King);
            CurrentGame.Queue.Enqueue(CurrentGame.Challenger);
            List<TeamModel> Teams = new List<TeamModel>(CurrentGame.Queue); 
            Teams.Sort(CompareTeamsByPoints);
            Teams.RemoveAt(0);
            CurrentGame.Queue = new Queue<TeamModel>(Teams);

            // Set king and challenger
            CurrentGame.King = CurrentGame.Queue.Dequeue();
            CurrentGame.Challenger = CurrentGame.Queue.Dequeue();
        }

        public void GameEnd()
        {
            CurrentGame.Queue.Enqueue(CurrentGame.King);
            CurrentGame.Queue.Enqueue(CurrentGame.Challenger);
            List<TeamModel> Teams = new List<TeamModel>(CurrentGame.Queue);
            Teams.Sort(CompareTeamsByPoints);
        }

        public int CompareTeamsByPoints(TeamModel t1, TeamModel t2)
        {
            if (t1.Score > t2.Score)
            {
                return 1;
            } else if (t1.Score < t2.Score)
            {
                return -1;
            } else
            {
                return 0;
            }
        }

        public void ChallengerScores()
        {
            CurrentGame.Queue.Enqueue(CurrentGame.King);
            CurrentGame.King = CurrentGame.Challenger;
            CurrentGame.Challenger = CurrentGame.Queue.Dequeue();
        }

        public void KingScores()
        {
            CurrentGame.King.Score++;

            if (CurrentGame.Stage == 3 && CurrentGame.King.Score == 15)
            {
                GameEnd();
                return;
            }

            CurrentGame.Queue.Enqueue(CurrentGame.Challenger);
            CurrentGame.Challenger = CurrentGame.Queue.Dequeue();
        }
    }
}
