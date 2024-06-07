namespace IW7PP.ViewModel
{
    public class ProsthesisVM
    {
        public int Id { get; set; }
        public int? SocketId { get; set; }
        public int? LinerId { get; set; }
        public int? TubeId { get; set; }
        public int? FootId { get; set; }
        public int? UnionSocketId { get; set; }
        public int? KneeArticulateId { get; set; }
        public Guid? UpperLimbAmputationsiD { get; set; }

        public Guid? LowerLimbAmputationsiD { get; set; }

        public double Durability { get; set; }

        public double AverageDurability { get; set; }


    }
}
