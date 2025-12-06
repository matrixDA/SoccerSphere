namespace SoccerSphere.Models
{
    public class PlayerTeamViewModel
    {
        public List<Player>? Players { get; set; }
        public List<Team>? Teams { get; set; }
        public Player CurrentPlayer { get; set; }
        public Team? CurrentTeam { get; set; }
    }
}
