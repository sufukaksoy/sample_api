﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sample_api.Data;
using sample_api.Models;

internal class Program
{
    

    static async Task Main(string[] args)
    {
        // Step 3: Retrieve data from API
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://64086c242f01352a8a9261b0.mockapi.io/api/v1/users");
        var content = await response.Content.ReadAsStringAsync();

        // Step 4: Deserialize JSON response into list of model class instances
        var data = JsonConvert.DeserializeObject<List<User>>(content);
        // Step 5: Create new instance of DbContext class
        await using var context = new UserContext();
        foreach (var item in data)
        {
            var objectExists = await context.Users.AnyAsync(o => o.id == item.id);

            if (!objectExists)
            {
                var uniqueUser = new User
                {
                    id = item.id,
                    name = item.name,
                    createdAt = item.createdAt,
                    avatar = item.avatar
                };
                context.Users.Add(uniqueUser);
                //await context.AddRangeAsync(data);

                // Step 7: Save changes to database
                await context.SaveChangesAsync();
            }
            else
                Console.WriteLine("User" + " " + item.id + " " + "'" + item.name + "'" + " " + "already exists");
        }
        Console.WriteLine("Process is ended...");
    }
}
