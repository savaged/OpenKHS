namespace OpenKHS.Models
{
    public class ClmmSchedule : Schedule
    {
        public ClmmSchedule()
            : base()
        {
            Treasures = new Assignment();
            Gems = new Assignment();
            BibleReading = new Assignment();
            Demo1Publisher = new Assignment();
            Demo1Householder = new Assignment();
            Demo2Publisher = new Assignment();
            Demo2Householder = new Assignment();
            Demo3Publisher = new Assignment();
            Demo3Householder = new Assignment();
            ApplyYourselfToTheMinistryTalk = new Assignment();
            LivingAsChristiansPart1 = new Assignment();
            LivingAsChristiansPart2 = new Assignment();
            LivingAsChristiansPart3 = new Assignment();
            CongregationBibleStudy = new Assignment();
        }

        public Assignment Treasures { get; set; }

        public Assignment Gems { get; set; }
        
        public Assignment BibleReading { get; set; }
        
        public Assignment Demo1Publisher { get; set; }
        public Assignment Demo1Householder { get; set; }

        public Assignment Demo2Publisher { get; set; }
        public Assignment Demo2Householder { get; set; }

        public Assignment Demo3Publisher { get; set; }
        public Assignment Demo3Householder { get; set; }

        public Assignment ApplyYourselfToTheMinistryTalk { get; set; }

        public Assignment LivingAsChristiansPart1 { get; set; }

        public Assignment LivingAsChristiansPart2 { get; set; }

        public Assignment LivingAsChristiansPart3 { get; set; }

        public Assignment CongregationBibleStudy { get; set; }

    }
}