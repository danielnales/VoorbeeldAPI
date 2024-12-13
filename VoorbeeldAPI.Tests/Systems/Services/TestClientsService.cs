using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using VoorbeeldAPI.Models;
using VoorbeeldAPI.Services;
using VoorbeeldAPI.Tests.Fixtures;
using VoorbeeldAPI.Tests.Helpers;

namespace VoorbeeldAPI.Tests.Systems.Services;

public class TestClientsService
{
    [Fact]
    public async Task CreateClient_ShouldReturnTrue()
    {
        // Arrange
        var context = InMemoryDatabaseFactory.CreateMockContext();
        var sut = new ClientsService(context);

        // Act
        var result = await sut.CreateClient(ClientFixtures.Client);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CreateClient_ShouldAddClient()
    {
        // Arrange
        var client = ClientFixtures.Client;
        var context = InMemoryDatabaseFactory.CreateMockContext();
        var sut = new ClientsService(context);

        // Act
        await sut.CreateClient(client);

        // Assert
        context.Clients.Should().Contain(client);
    }

    [Fact]
    public async Task GetAllClients_ShouldReturnClientDtos()
    {
        // Arrange
        var clients = ClientFixtures.GenerateClients(20);
        var context = InMemoryDatabaseFactory.CreateMockContext();
        await InMemoryDatabaseFactory.SeedData(context, clients);
        var sut = new ClientsService(context);

        // Act
        var result = await sut.GetAllClients();

        // Assert
        result.Should().NotBeEmpty();
        result.Should().BeOfType<List<ClientDto>>();
        result.Should().BeEquivalentTo(clients.Select(c => c.Dto));
    }

    [Fact]
    public async Task GetClientById_ShouldReturnClientDto()
    {
        // Arrange
        var client = ClientFixtures.Client;
        var context = InMemoryDatabaseFactory.CreateMockContext();
        await InMemoryDatabaseFactory.SeedData(context, client);
        var sut = new ClientsService(context);

        // Act
        var result = await sut.GetClientById(client.Id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ClientDto>();
        result.Should().BeEquivalentTo(client.Dto);
    }

}