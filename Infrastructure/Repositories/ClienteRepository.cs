using Domain.Models;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class ClienteRepository
{
    private readonly IMongoCollection<Cliente> _clientes;

    // Constructor que configura a conexão com o MongoDB e inicializa a coleção de clientes
    public ClienteRepository(string connectionString, string databaseName)
    {
        // Cria uma nova instância do cliente MongoDB usando a string de conexão fornecida
        var client = new MongoClient(connectionString);

        // Obtém o banco de dados do MongoDB com base no nome fornecido
        var database = client.GetDatabase(databaseName);

        // Obtém a coleção de clientes dentro do banco de dados
        _clientes = database.GetCollection<Cliente>("clientes");
    }

    // Método para obter todos os clientes da coleção
    public async Task<List<Cliente>> ObterTodosClientes()
    {
        // Retorna uma lista de todos os documentos na coleção de clientes
        return await _clientes.Find(cliente => true).ToListAsync();
    }

    // Método para obter um cliente por ID
    public async Task<Cliente> ObterClientePorId(Guid id)
    {
        // Procura um cliente com o ID fornecido e retorna o primeiro resultado
        return await _clientes.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefaultAsync();
    }

    // Método para adicionar um novo cliente à coleção
    public async Task AdicionarCliente(Cliente cliente)
    {
        // Insere um novo documento de cliente na coleção
        await _clientes.InsertOneAsync(cliente);
    }

    // Método para atualizar um cliente existente com base no ID
    public async Task AtualizarCliente(Guid id, Cliente cliente)
    {
        // Substitui o documento com o ID correspondente pelo novo cliente fornecido
        await _clientes.ReplaceOneAsync(c => c.Id == id, cliente);
    }

    // Método para excluir um cliente com base no ID
    public async Task ExcluirCliente(Guid id)
    {
        // Exclui o documento com o ID correspondente da coleção
        await _clientes.DeleteOneAsync(cliente => cliente.Id == id);
    }
}