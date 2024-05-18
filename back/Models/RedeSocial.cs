
namespace back.Models;

public class RedeSocial 
{
    public RedeSocial(string descricao, string url)  {
        Url = url;
        Descricao = descricao;
    }

    public int Id { get; set; }
    public string Url { get; set; }
    public string Descricao { get; set; }

    public int? OngId { get; set; }
    public Ong? Ong { get; set; }
    
    public int? TutorId { get; set; }
    public Tutor? Tutor { get; set; }
}