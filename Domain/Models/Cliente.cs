namespace Domain.Models;

public class Cliente
{
    // Propriedade para o ID do cliente
    public Guid Id { get; set; }

    // Propriedade para o nome do cliente, podendo ser nulo
    public string? Nome { get; set; }

    // Propriedade para o e-mail do cliente, podendo ser nulo
    public string? Email { get; set; }
}
