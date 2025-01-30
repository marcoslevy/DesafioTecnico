using Vendas.Core.Entities;

namespace Vendas.Application.Models;

public class ClienteViewModel
{
    public ClienteViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }

    public static ClienteViewModel Instance(Cliente cliente)
        => new(cliente.Id, cliente.Nome);
}
