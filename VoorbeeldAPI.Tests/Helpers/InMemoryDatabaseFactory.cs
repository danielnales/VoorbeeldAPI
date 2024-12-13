using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using VoorbeeldAPI.Shared;

namespace VoorbeeldAPI.Tests.Helpers;

static class InMemoryDatabaseFactory
{
    public static VoorbeeldDbContext CreateMockContext(string databaseName = "")
    {
        if (databaseName == "")
        {
            databaseName = Guid.NewGuid().ToString();
        }

        var options = new DbContextOptionsBuilder<VoorbeeldDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;
        var context = new VoorbeeldDbContext(options);
        return context;
    }

    public static async Task<bool> SeedData<T>(VoorbeeldDbContext context, T[] values) where T : class
    {
        await context.Set<T>().AddRangeAsync(values);
        return await context.SaveChangesAsync() > 0;
    }

    public static async Task<bool> SeedData<T>(VoorbeeldDbContext context, T value) where T : class
    {
        await context.Set<T>().AddAsync(value);
        return await context.SaveChangesAsync() > 0;
    }
}
