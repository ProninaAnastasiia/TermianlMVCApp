namespace TermianlMVCApp.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string CommandText { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public DateTime DateTimeSent { get; set; }
        public string Status { get; set; }
    }

    /*enum Status
    {
        Sending, 
        Delivered,
        NotDelivered
    }*/

}
