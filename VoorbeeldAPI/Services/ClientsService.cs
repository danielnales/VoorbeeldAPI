using Microsoft.EntityFrameworkCore;
using VoorbeeldAPI.Models;
using VoorbeeldAPI.Shared;

namespace VoorbeeldAPI.Services;

public interface IClientsService
{
    public Task<IEnumerable<ClientDto>> GetAllClients();
    public Task<ClientDto?> GetClientById(Guid id);
    public Task<bool> CreateClient(Client clientDto);
}

public class ClientsService(VoorbeeldDbContext context) : IClientsService
{
    public async Task<bool> CreateClient(Client client)
    {
        context.Clients.Add(client);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<ClientDto>> GetAllClients()
    {
        return await context.Clients.Select(c => c.Dto).ToListAsync();
    }

    public async Task<ClientDto?> GetClientById(Guid id)
    {
        var client = await context.Clients.FindAsync(id);
        return client?.Dto;
    }
}
