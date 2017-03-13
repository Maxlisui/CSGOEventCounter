namespace CSGO_Event_Recorder.Model
{
    public class Statistic
    {
        private string _team1;
        private string _team2;
        private string _score;
        private string _event;

        public string Team1 { get => _team1; set => _team1 = value; }
        public string Score { get => _score; set => _score = value; }
        public string Team2 { get => _team2; set => _team2 = value; }
        public string Event { get => _event; set => _event = value; }
    }
}