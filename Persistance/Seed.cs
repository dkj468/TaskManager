using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Activities.Any()) return;

            var activities = new List<Activity>
            {
                new Activity
                {
                    Name = "Complete the course",
                    Description = "Complete the .NET learning course",
                    Created = DateTime.Now,
                    Tags    = "learning,ASP.NET core,"
                },
                new Activity
                {
                    Name="submit the WFH bill",
                    Description="Submit the WFH office supply bill",
                    Created= DateTime.Now,
                    Tags="WFH,Chair,bill"
                },
                new Activity
                {
                    Name="make appointment for driving license",
                    Description="Go to RTO office and book appointment for 4 wheeler license",
                    Created=DateTime.Now,
                    Tags="driving,appointment"
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}
