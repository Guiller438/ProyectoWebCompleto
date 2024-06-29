using IW7PP.Models.ProsthesisM;

namespace IW7PP.ViewModel
{
    public class ProsthesisFilterVM
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ProsthesisVM> UpperProstheses { get; set; }
        public List<ProsthesisVM> LowerProstheses { get; set; }

    }
}
