namespace GestaoMicroestrutural.Domain.Entities;

public class Insumo : AtivoFisico
{
    public string Tipo { get; private set; } = null!;
    public string UnidadeMedida { get; private set; } = null!;
    public decimal QuantidadeDisponivel { get; private set; }
    public decimal EstoqueMinimo { get; private set; }

    protected Insumo() { }

    public Insumo(string tipo, string descricao, string unidadeMedida, decimal estoqueMinimo, string tenantId)
    : base(Guid.NewGuid(), tenantId, NaturezaAtivo.Consumo, descricao)
    {
        Tipo = tipo;
        UnidadeMedida = unidadeMedida;
        EstoqueMinimo = estoqueMinimo;
        QuantidadeDisponivel = 0;
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