namespace GestaoMicroestrutural.Domain.Entities;

public class Insumo
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public string UnidadeMedida { get; private set; } = null!;
    public decimal QuantidadeDisponivel { get; private set; }
    public decimal EstoqueMinimo { get; private set; }

    protected Insumo() { }

    public Insumo(string nome, string unidadeMedida, decimal estoqueMinimo)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        UnidadeMedida = unidadeMedida;
        QuantidadeDisponivel = 0;
        EstoqueMinimo = estoqueMinimo;
    }
    
    public void RealizarBaixa(decimal quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade para baixa deve ser maior que zero.");
            
        if (QuantidadeDisponivel < quantidade)
            throw new InvalidOperationException("Quantidade disponível insuficiente para a baixa.");

        QuantidadeDisponivel -= quantidade;
    }
}