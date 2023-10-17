// ClienteService.cs
using System;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class ClienteService
{
    private readonly ClienteRepository _clienteRepository;

    public ClienteService(ClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task AdicionarNovoCliente(Cliente cliente)
    {
        var clienteExistente = await _clienteRepository.ObterClientePorId(cliente.Id);

        if (clienteExistente != null)
        {
            Console.WriteLine("Cliente com este ID já existe no banco de dados.");
            return;
        }

        await _clienteRepository.AdicionarCliente(cliente);
    }

    public async Task ListarClientes()
    {
        var clientes = await _clienteRepository.ObterTodosClientes();
        Console.WriteLine("Listando todos os clientes");

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Email: {cliente.Email}");
        }
    }

    public async Task AtualizarCliente(Guid id, Cliente cliente)
    {
        // Adicione aqui a lógica para atualizar um cliente
        await _clienteRepository.AtualizarCliente(id, cliente);
    }

    public async Task ObterClientePorId(Guid id)
    {
        // Adicione aqui a lógica para obter um cliente por ID
        await _clienteRepository.ObterClientePorId(id);
    }

    public async Task ExcluirCliente(Guid id)
    {
        // Adicione aqui a lógica para excluir um cliente por ID
        await _clienteRepository.ExcluirCliente(id);
    }
}