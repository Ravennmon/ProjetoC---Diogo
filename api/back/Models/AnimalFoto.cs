
namespace back.Models;

using System.ComponentModel.DataAnnotations;

public class AnimalFoto 
{
    public AnimalFoto(string url, int animalId)
    {
        Url = url;
        AnimalId = animalId;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Url(ErrorMessage = "Url inválida")]
    public string Url { get; set; }

    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }
}