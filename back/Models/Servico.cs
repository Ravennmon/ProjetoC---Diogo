
namespace back.Models;

public class Servico
{
    public Servico(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public int? OngId { get; set; }
    public Ong Ong { get; set; }

    public int? CuidadorId { get; set; }
    public Cuidador Cuidador { get; set; }
}