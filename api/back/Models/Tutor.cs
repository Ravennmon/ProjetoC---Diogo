namespace back.Models;

using System.ComponentModel.DataAnnotations;
using back.Validations;

public class Tutor
{
    public Tutor(string nome, string email, string cpfCnpj, string telefone, string endereco, DateTime dataNascimento)  {
        Nome = nome;
        Email = email;
        CpfCnpj = cpfCnpj;
        Telefone = telefone;
        Endereco = endereco;
        DataNascimento = dataNascimento;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(11)]
    [MaxLength(18)]
    public string CpfCnpj { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(8)]
    [MaxLength(20)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [DataType(DataType.Date, ErrorMessage = "Data inválida")]
    [MaiorDeIdade(ErrorMessage = "O tutor deve ser maior de idade")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Endereco { get; set; }

    public ICollection<RedeSocial>? RedesSociais { get; set; }
    public ICollection<Animal>? Animais { get; set; }
}