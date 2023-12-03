using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {   
            if (context.Activities.Any()) return;
            var activities = new List<Activity>
            {
                new()
                {
                    Title = "Past Activity 1",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Activity 1 two months ago",
                    Category = "Music",
                    City = "Singapore, Singapore",
                    Venue = "Somewhere on Singapore"
                },

                new()
                {
                    Title = "Past Activity 2",
                    Date = DateTime.UtcNow.AddMonths(-5),
                    Description = "Activity 2 five months ago",
                    Category = "Travel",
                    City = "Seattle, United States",
                    Venue = "Somewhere on Seattle"
                },
                new()
                {
                    Title = "Past Activity 3",
                    Date = DateTime.UtcNow.AddMonths(-7),
                    Description = "Activity 3 seven months ago",
                    Category = "Food",
                    City = "Dallas, United States",
                    Venue = "Somewhere on Dallas"
                },
                new()
                {
                    Title = "Future Activity 1",
                    Date = DateTime.UtcNow.AddMonths(2),
                    Description = "Activity 1 two months ahead",
                    Category = "Music",
                    City = "Singapore, Singapore",
                    Venue = "Somewhere on London"
                },
                new()
                {
                    Title = "Future Activity 2",
                    Date = DateTime.UtcNow.AddMonths(5),
                    Description = "Activity 2 five months ahead",
                    Category = "Travel",
                    City = "Seattle, United States",
                    Venue = "Somewhere on Seattle"
                },
                new()
                {
                    Title = "Future Activity 3",
                    Date = DateTime.UtcNow.AddMonths(7),
                    Description = "Activity 3 seven months ago",
                    Category = "Food",
                    City = "Dallas, United States",
                    Venue = "Somewhere on Dallas"
                }
            };
            
            // adds the array of activities to the memory
            await context.Activities.AddRangeAsync(activities);

            // does, definetely, the transaction
            await context.SaveChangesAsync();
        }
    }
}