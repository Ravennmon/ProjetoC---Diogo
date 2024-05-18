
namespace back.Models;

public class Servico
{
    public Servico(string nome, string descricao, int ongId)
    {
        Nome = nome;
        Descricao = descricao;
        OngId = ongId;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public int OngId { get; set; }
    public Ong? Ong { get; set; }
}