namespace Domain
{
    public class Activity
    {       
        // EF Core needs the properties to be public, so it can access them
        // each entity/model is a database table.
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}