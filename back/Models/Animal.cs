
namespace back.Models;

using System.ComponentModel.DataAnnotations;
using back.Enums;
using back.Validations;

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

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public TipoAnimal Tipo { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [DataType(DataType.Date, ErrorMessage = "Data inválida")]
    [DateValidation(ErrorMessage = "A data de nascimento inválida")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(25)]
    public string Raca { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(20)]
    public string Porte { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Range(0.1, 1000, ErrorMessage = "Peso inválido")]
    public float Peso { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(10)]
    public string? Sexo { get; set; }

    [MinLength(3)]
    [MaxLength(200)]
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