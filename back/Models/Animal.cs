
namespace back.Models;
using back.Enums;

public class Animal 
{
    public Animal(string nome, TipoAnimal tipo, DateTime dataNascimento, string raca, string porte, float peso, string sexo, string observacao, int ongId)  
    {
        Nome = nome;
        Tipo = tipo;
        DataNascimento = dataNascimento;
        Raca = raca;
        Porte = porte;
        Peso = peso;
        Sexo = sexo;
        Observacao = observacao;
        OngId = ongId;
        Fotos = new List<AnimalFoto>();
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoAnimal Tipo { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Raca { get; set; }
    public string Porte { get; set; }
    public float Peso { get; set; }
    public string Sexo { get; set; }
    public string? Observacao { get; set; }

    public int OngId { get; set; }
    public Ong? Ong { get; set; }

    public int? TutorId { get; set; }
    public Tutor? Tutor { get; set; }

    public ICollection<AnimalFoto>? Fotos { get; set; }

    public bool Adotado
    {
        get
        {
            return TutorId != null;
        }
    }
}