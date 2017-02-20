namespace CSGO_Event_Recorder.Model
{
    public class Event
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Date {get; set;}
        public string Venue {get; set;}
        public int OrganizerID {get; set;}
        public Organizer Organizer {get; set;}

    }
}