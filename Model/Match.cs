namespace CSGO_Event_Recorder.Model
{
    public class Match
    {
        public int Id {get; set;}
        public int Map {get; set;}
        public int Team1 {get; set;}
        public int Team2 {get; set;}
        public int Team1Score {get; set;}
        public int Team2Score{get; set;}
        public int Team1AttackedA {get; set;}
        public int Team1AttackedASuccess {get; set;}
        public int Team1AttackedB {get; set;}
        public int Team1AttackedBSuccess {get; set;}
        public int Team2AttackedA {get; set;}
        public int Team2AttackedASuccess {get; set;}
        public int Team2AttackedB {get; set;}
        public int Team2AttackedBSuccess {get; set;}
        public int Team1RetakeASuccess {get; set;}
        public int Team1RetakeBSuccess {get; set;}
        public int Team2RetakeASuccess {get; set;}
        public int Team2RetakeBSuccess {get; set;}
    }
}