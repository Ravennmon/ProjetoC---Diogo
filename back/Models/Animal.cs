
namespace back.Models;
using back.Enums;

public class Animal 
{
    public Animal(string nome, TipoAnimal tipo, DateTime dataNascimento, string raca, string porte, float peso, string sexo, string observacao)  
    {
        Nome = nome;
        Tipo = tipo;
        DataNascimento = dataNascimento;
        Raca = raca;
        Porte = porte;
        Peso = peso;
        Sexo = sexo;
        Observacao = observacao;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoAnimal Tipo { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Raca { get; set; }
    public string Porte { get; set; }
    public float Peso { get; set; }
    public string Sexo { get; set; }
    public string Observacao { get; set; }

    public int? OngId { get; set; }
    public Ong Ong { get; set; }

    public int? CuidadorId { get; set; }
    public Cuidador Cuidador { get; set; }
}