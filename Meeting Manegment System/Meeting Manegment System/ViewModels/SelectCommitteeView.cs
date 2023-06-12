using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.ViewModels
{
    public class SelectCommitteeView
    {
        public Member member { get; set; }
        public List<Committee> commits { get; set; }
        public int SelectedId { get; set; }
    }
}
