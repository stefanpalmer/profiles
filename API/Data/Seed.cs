using API.Entities;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}