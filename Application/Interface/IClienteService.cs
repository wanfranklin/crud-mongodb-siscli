using Domain.Models;

namespace Application.Interface;

public interface IClienteService
{
    // Método para obter todos os clientes
    Task<List<Cliente>> ObterTodosClientes();

    // Método para obter um cliente por ID
    Task<Cliente> ObterClientePorId(Guid id);

    // Método para adicionar um novo cliente
    Task AdicionarNovoCliente(Cliente cliente);

    // Método para atualizar um cliente existente por ID
    Task AtualizarClienteExistente(Guid id, Cliente cliente);

    // Método para excluir um cliente por ID
    Task ExcluirClientePorId(Guid id);
}