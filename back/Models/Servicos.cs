
namespace BACK.Models;
public class Servicos 
{
    public Servicos( string nome, string descricao)  {
        Nome = nome;
        Descricao = descricao;
        Id = Guid.NewGuid().ToString();
    }

    public Servicos(){}

    public string Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }


}