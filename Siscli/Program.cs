﻿
using MongoDB.Driver;
using Siscli.Data;
using Siscli.Model;

// Definição da string de conexão com o MongoDb
string connectionString = "mongodb://localhost:27017";
// Nome do banco de dados no MongoDB
string databaseName = "Siscli";

try
{
    // Tentativa de estabelecer conexão com o MongoDB usando a string de conexão
    var client = new MongoClient(connectionString);
    var database = client.GetDatabase(databaseName);
    
    Console.WriteLine("Conexão com o MongoDB estabelecia com sucesso!");

    // Criação de uma instância do repositório do cliente, que lida com operações CRUD no banco de dados
    var clienteRepository = new ClienteRepository(connectionString, databaseName);

    // Criar e adicionar um novo cliente
    Cliente novoCliente = new Cliente();
    novoCliente.Id = new Guid();

    Console.WriteLine("Digite cliente:");
    novoCliente.Nome = Console.ReadLine();

    Console.WriteLine("Digite o email:");
    novoCliente.Email = Console.ReadLine();

    await clienteRepository.AdicionarCliente(novoCliente);
    Console.WriteLine("Novo cliente adicionado com sucesso ao MongoDB");

    // Listar todos os clientes
    var clientes = await clienteRepository.ObterTodosClientes();
    Console.WriteLine("Listando todos os clientes");

    foreach (var cliente in clientes)
    {
        Console.WriteLine($"Nome: {cliente.Nome}, Email: {cliente.Email}");
    }

}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar ao MongoDB: {ex.Message}");
    return; // sai do método se a conexão falhar
}





