namespace IW7PP.Models.ProsthesisM
{
    public class ComponentUsageStatistics
    {
        public string ComponentType { get; set; }
        public string ComponentName { get; set; }
        public int UsageCount { get; set; }

        public double AverageDurability { get; set; }

        public string AmputationType { get; set; }
    }
}
