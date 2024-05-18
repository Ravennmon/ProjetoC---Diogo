
namespace back.Models;
using back.Enums;

public class AnimalFoto 
{
    public AnimalFoto(string url, int animalId)
    {
        Url = url;
        AnimalId = animalId;
    }

    public int Id { get; set; }
    public string Url { get; set; }

    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }
}