using Application.Services;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

var currentDirectory = Directory.GetCurrentDirectory();
var projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;

var configuration = new ConfigurationBuilder()
    .SetBasePath(projectDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var mongoDbSettings = configuration.GetSection("MongoDBSettings");
if (mongoDbSettings == null)
{
    Console.WriteLine("Configurações do MongoDB não encontradas no appsettings.json.");
    return;
}

string connectionString = mongoDbSettings["ConnectionString"];
string databaseName = mongoDbSettings["DatabaseName"];

if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
{
    Console.WriteLine("Configurações de conexão do MongoDB não estão definidas corretamente no appsettings.json.");
    return;
}

Console.WriteLine($"ConnectionString: {connectionString}");
Console.WriteLine($"DatabaseName: {databaseName}");

try
{
    var clienteRepository = new ClienteRepository(connectionString, databaseName);
    var clienteService = new ClienteService(clienteRepository);

    string resposta;
    do
    {
        Cliente novoCliente = new Cliente();
        novoCliente.Id = Guid.NewGuid();

        Console.WriteLine("Digite o nome do cliente:");
        novoCliente.Nome = Console.ReadLine();

        Console.WriteLine("Digite o email do cliente:");
        novoCliente.Email = Console.ReadLine();

        await clienteService.AdicionarNovoCliente(novoCliente);
        Console.WriteLine("Novo cliente adicionado com sucesso ao MongoDB");

        Console.WriteLine("Deseja adicionar outro cliente? (s/n)");
        resposta = Console.ReadLine();
    } while (resposta.ToLower() == "s");

    await clienteService.ListarClientes();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
    return;
}