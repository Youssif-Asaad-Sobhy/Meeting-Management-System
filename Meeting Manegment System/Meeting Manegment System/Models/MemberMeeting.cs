using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public enum State
    {
        Execuse,
        Attend,
        NotAnswerd
    };
    public class MemberMeeting
    {
        [Key]
        public int MemberMeetingId { get; set; }
        public int MemberId { get; set; }
        public int MeetingId { get; set; }
        public State Response { get; set; }= State.NotAnswerd;
        public Member Member { get; set; }
        public Meeting Meeting { get; set; }
    }
}
