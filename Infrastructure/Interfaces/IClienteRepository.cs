using Domain.Models;

namespace Infrastructure.Interfaces
{
    // Definição da interface IClienteRepository
    public interface IClienteRepository
    {
        // Método para obter todos os clientes
        Task<List<Cliente>> ObterTodosClientes();

        // Método para obter um cliente por ID
        Task<Cliente> ObterClientePorId(Guid id);

        // Método para adicionar um cliente
        Task AdicionarCliente(Cliente cliente);

        // Método para atualizar um cliente por ID
        Task AtualizarCliente(Guid id, Cliente cliente);

        // Método para excluir um cliente por ID
        Task ExcluirCliente(Guid id);
    }
}
