namespace superheroAPI
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AlterEgo { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string FirstAppearence { get; set; } = string.Empty;
        public int PublishingYear { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
