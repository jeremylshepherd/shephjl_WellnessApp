namespace shephjl_WellnessApp.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum WellnessStatus
    {
        Excellent,
        Good,
        Fair,
        Poor
    }

    public class WellnessData
    {
        public Gender SelectedGender { get; set; }
        public double SleepHours { get; set; }
        public double StressLevel { get; set; }
        public double ActivityMinutes { get; set; }
        public int WellnessScore { get; set; }
        public WellnessStatus Status { get; set; }
        public string Recommendation { get; set; }
    }
}