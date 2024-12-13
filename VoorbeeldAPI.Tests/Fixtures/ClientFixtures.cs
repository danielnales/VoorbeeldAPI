using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoorbeeldAPI.Models;

namespace VoorbeeldAPI.Tests.Fixtures;

public static class ClientFixtures
{
    public static Client Client => new()
    {
        Id = Guid.NewGuid(),
        Name = "Client 1",
        Email = "Client1@gmail.com",
        Password = "Password1",
        Phone = "+31 0638659093"
    };

    public static Client[] GenerateClients(int count)
    {
        return Enumerable.Range(0, count).Select(i => new Client
        {
            Id = Guid.NewGuid(),
            Name = $"Client {i + 1}",
            Email = $"Client{i + 1}@gmail.com",
            Password = $"Password{i + 1}",
            Phone = "+31 0638659093"
        }).ToArray();
    }
}
