// Importação dos namespaces necessários
using Application.Services;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Presentation.Utils;

// Obtém o diretório atual e o diretório do projeto
var currentDirectory = Directory.GetCurrentDirectory();
var projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;

// Configuração do arquivo de configuração
var configuration = new ConfigurationBuilder()
    .SetBasePath(projectDirectory) // Define o diretório base para o arquivo de configuração
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Carrega o arquivo de configuração JSON
    .Build(); // Constrói a configuração

// Obtém a seção de configurações do MongoDB do arquivo de configuração
var mongoDbSettings = configuration.GetSection("MongoDBSettings");
if (mongoDbSettings == null)
{
    Console.WriteLine("Configurações do MongoDB não encontradas no appsettings.json.");
    return;
}

// Obtém a string de conexão e o nome do banco de dados do arquivo de configuração
string connectionString = mongoDbSettings["ConnectionString"];
string databaseName = mongoDbSettings["DatabaseName"];

// Verifica se a string de conexão ou o nome do banco de dados estão vazios
if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
{
    Console.WriteLine("Configurações de conexão do MongoDB não estão definidas corretamente no appsettings.json.");
    return;
}

// Imprime a string de conexão e o nome do banco de dados
Console.WriteLine($"{ConsoleColors.Green}ConnectionString: {ConsoleColors.Reset}{connectionString}.");
Console.WriteLine($"{ConsoleColors.Green}DatabaseName: {ConsoleColors.Reset}{databaseName}.");

try
{
    // Cria uma instância do repositório de cliente e do serviço de cliente
    var clienteRepository = new ClienteRepository(connectionString, databaseName);
    var clienteService = new ClienteService(clienteRepository);

    // Loop para adicionar vários clientes
    string resposta;
    do
    {
        // Cria um novo cliente e solicita ao usuário para inserir os detalhes do cliente
        Cliente novoCliente = new Cliente();
        novoCliente.Id = Guid.NewGuid();

        Console.WriteLine("");
        Console.WriteLine("Digite o nome do cliente:");
        novoCliente.Nome = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("Digite o email do cliente:");
        novoCliente.Email = Console.ReadLine();

        // Adiciona o novo cliente
        await clienteService.AdicionarNovoCliente(novoCliente);
        Console.WriteLine("");
        Console.WriteLine($"{ConsoleColors.Green}Novo cliente adicionado com sucesso ao MongoDB.{ConsoleColors.Reset}");


        // Pergunta ao usuário se deseja adicionar outro cliente
        Console.WriteLine("");
        Console.WriteLine($"{ConsoleColors.Yellow}Deseja adicionar outro cliente? (s/n).{ConsoleColors.Reset}");
        resposta = Console.ReadLine();
    } while (resposta.ToLower() == "s");

    // Lista todos os clientes
    Console.WriteLine("");
    await clienteService.ListarClientes();
}
catch (Exception ex)
{
    // Captura e imprime qualquer exceção
    Console.WriteLine($"{ConsoleColors.Red}Erro: {ex.Message}{ConsoleColors.Reset}");
    return;
}