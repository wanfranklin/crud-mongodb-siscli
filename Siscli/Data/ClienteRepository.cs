using MongoDB.Driver;
using Siscli.Model;

namespace Siscli.Data;

public class ClienteRepository
{
    private readonly IMongoCollection<Cliente> _clientes;

    // Construtor que recebe a string de conexão e nome do banco de dados (MongoDB)
    public ClienteRepository(string connectionString, string databaseName)
    {
        // Cria uma instância do cliente MongoDB usando a string de conexão
        var client = new MongoClient(connectionString);

        // Obtém o banco de dados do MongoDB com base no nome fornecido
        var database = client.GetDatabase(databaseName);

        // Obtém a coleção de clientes do banco de dados
        _clientes = database.GetCollection<Cliente>("clientes");
    }

    // Método para obter todos os clientes no banco de dados
    public async Task<List<Cliente>> ObterTodosClientes()
    {
        // Retorna uma lista de todos os documentos na coleção de clientes
        return await _clientes.Find(cliente => true).ToListAsync();
    }

    // Método para obter um clente por Id
    public async Task<Cliente> ObterClientePorId(long id)
    {
        // Procura um cliente com o ID fornecido e retorna o primeiro registro
        return await _clientes.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefaultAsync();
    }

    // Método para adicionar um novo cliente
    public async Task AdicionarCliente(Cliente cliente)
    {
        // Insere um novo documento de cliente na coleção
        await _clientes.InsertOneAsync(cliente);
    }
}