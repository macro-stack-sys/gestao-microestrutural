namespace GestaoMicroestrutural.Domain.Entities;

public class Sala
{
    public Guid Id { get; private set; }
    public Guid BlocoId { get; private set; }
    public string Nome { get; private set; }
    public string? Tipo { get; private set; }
    
    public virtual Bloco Bloco { get; private set; }

    protected Sala() { }

    public Sala(Guid blocoId, string nome, string? tipo)
    {
        Id = Guid.NewGuid();
        BlocoId = blocoId;
        Nome = nome;
        Tipo = tipo;
    }
}