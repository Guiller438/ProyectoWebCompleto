using System.ComponentModel.DataAnnotations;
using IW7PP.Models.Amputations; 

namespace IW7PP.Models.ProsthesisM
{
    public class Prosthesis
    {
        [Key]
        public int Id { get; set; }
        public int? SocketId { get; set; }
        public int? LinerId { get; set; }
        public int? TubeId { get; set; }
        public int? FootId { get; set; }
        public int? UnionSocketId { get; set; }
        public int? KneeArticulateId { get; set; }

        public Guid? UpperLimbAmputationsiD{  get; set; }

        public Guid? LowerLimbAmputationsiD { get; set; }

        public double Durability { get; set; }

        public double AverageDurability { get; set; }

        // Navigation properties
        public Socket Socket { get; set; }
        public Liner Liner { get; set; }
        public Tube Tube { get; set; }
        public Foot Foot { get; set; }
        public UnionSocket UnionSocket { get; set; }
        public KneeArticulate RodillaArticulada { get; set; }
        public UpperLimbAmputation UpperLimbAmputations { get; set; }
        public LowerLimbAmputation LowerLimbAmputations { get; set;}


    }
}
