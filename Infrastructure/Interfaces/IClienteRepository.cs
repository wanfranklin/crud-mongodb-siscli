using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObterTodosClientes();
        Task<Cliente> ObterClientePorId(Guid id);
        Task AdicionarCliente(Cliente cliente);
        Task AtualizarCliente(Guid id, Cliente cliente);
        Task ExcluirCliente(Guid id);
    }
}
