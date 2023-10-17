using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

// Classe responsável por fornecer serviços relacionados aos clientes
public class ClienteService
{
    private readonly ClienteRepository _clienteRepository;

    // Construtor que recebe uma instância de ClienteRepository para manipular os dados dos clientes
    public ClienteService(ClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    // Método para adicionar um novo cliente, verificando se o cliente já existe no banco de dados com o mesmo ID
    public async Task AdicionarNovoCliente(Cliente cliente)
    {
        // Verifica se um cliente com o mesmo ID já existe no banco de dados
        var clienteExistente = await _clienteRepository.ObterClientePorId(cliente.Id);

        // Se um cliente com o mesmo ID já existir, exibe uma mensagem e retorna da função
        if (clienteExistente != null)
        {
            Console.WriteLine("Cliente com este ID já existe no banco de dados.");
            return;
        }

        // Caso contrário, adiciona o novo cliente ao banco de dados
        await _clienteRepository.AdicionarCliente(cliente);
    }

    // Método para listar todos os clientes no banco de dados
    public async Task ListarClientes()
    {
        var clientes = await _clienteRepository.ObterTodosClientes();
        Console.WriteLine("Listando todos os clientes");

        // Itera sobre a lista de clientes e imprime os detalhes de cada cliente
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Email: {cliente.Email}");
        }
    }

    // Método para atualizar um cliente com base no ID
    public async Task AtualizarCliente(Guid id, Cliente cliente)
    {
        // Adicione aqui a lógica para atualizar um cliente com base no ID fornecido
        await _clienteRepository.AtualizarCliente(id, cliente);
    }

    // Método para obter um cliente por ID
    public async Task ObterClientePorId(Guid id)
    {
        // Adicione aqui a lógica para obter um cliente por ID
        await _clienteRepository.ObterClientePorId(id);
    }

    // Método para excluir um cliente por ID
    public async Task ExcluirCliente(Guid id)
    {
        // Adicione aqui a lógica para excluir um cliente por ID
        await _clienteRepository.ExcluirCliente(id);
    }
}