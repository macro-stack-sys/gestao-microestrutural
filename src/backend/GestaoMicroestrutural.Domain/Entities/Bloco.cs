namespace GestaoMicroestrutural.Domain.Entities;

public class Bloco
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string? Descricao { get; private set; }

    private readonly List<Sala> _salas = new();
    public IReadOnlyCollection<Sala> Salas => _salas.AsReadOnly();
    
    protected Bloco() { }

    public Bloco( string nome, string? descricao)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
    }
}