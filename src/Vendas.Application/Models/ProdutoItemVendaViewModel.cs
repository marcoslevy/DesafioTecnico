using Vendas.Core.Entities;

namespace Vendas.Application.Models;

public class ProdutoItemVendaViewModel
{
    public ProdutoItemVendaViewModel(int id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }

    public int Id { get; set; }
    public string Descricao { get; set; }

    public static ProdutoItemVendaViewModel Instance(Produto produto)
        => new(produto.Id, produto.Descricao);
}
