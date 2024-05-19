
namespace back.Models;

using System.ComponentModel.DataAnnotations;

public class RedeSocial 
{
    public RedeSocial(string descricao, string url)  {
        Url = url;
        Descricao = descricao;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Url(ErrorMessage = "Url inválida")]
    public string Url { get; set; }

    [MinLength(3)]
    [MaxLength(200)]
    public string Descricao { get; set; }

    public int? OngId { get; set; }
    public Ong? Ong { get; set; }
    
    public int? TutorId { get; set; }
    public Tutor? Tutor { get; set; }
}