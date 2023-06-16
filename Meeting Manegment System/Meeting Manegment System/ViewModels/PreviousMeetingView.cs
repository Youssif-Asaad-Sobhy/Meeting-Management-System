using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.ViewModels
{
    public class PreviousMeetingView
    {
        public int MemberId { get; set; }
        public List<Meeting> meetings { get; set; }
    }
}
