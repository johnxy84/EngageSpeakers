namespace EngageSpeakers
{
    public class Faci
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
    }
}