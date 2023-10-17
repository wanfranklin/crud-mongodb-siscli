using Domain.Models;

namespace Application.Interface;

public interface IClienteService
{
    Task<List<Cliente>> ObterTodosClientes();
    Task<Cliente> ObterClientePorId(Guid id);
    Task AdicionarNovoCliente(Cliente cliente);
    Task AtualizarClienteExistente(Guid id, Cliente cliente);
    Task ExcluirClientePorId(Guid id);
}