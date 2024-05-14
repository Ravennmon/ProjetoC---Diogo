
namespace back.Models;

public class Servico
{
    public Servico( string nome, string descricao)  {
        Nome = nome;
        Descricao = descricao;
    }
    
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}