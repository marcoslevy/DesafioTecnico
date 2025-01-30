using Vendas.Core.Entities;

namespace Vendas.Application.Models;

public class ProdutoViewModel
{
    public ProdutoViewModel(int id, string descricao, decimal valorUnitario)
    {
        Id = id;
        Descricao = descricao;
        ValorUnitario = valorUnitario;
    }

    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }

    public static ProdutoViewModel Instance(Produto produto)
        => new(produto.Id, produto.Descricao, produto.ValorUnitario);
}
