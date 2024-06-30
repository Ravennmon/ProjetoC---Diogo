namespace back.Models;

using System.ComponentModel.DataAnnotations;

public class Ong
{
    public Ong(string nome, string cnpj, string endereco, string telefone, string email)
    {
        Nome = nome;
        Cnpj = cnpj;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
        RedesSociais = new List<RedeSocial>();
        Animais = new List<Animal>();
        Servicos = new List<Servico>();
    }
   
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(14)]
    [MaxLength(18)]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(200)]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(8)]
    [MaxLength(20)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }
    public ICollection<RedeSocial> RedesSociais { get; set; }
    public ICollection<Animal> Animais { get; set; }
    public ICollection<Servico> Servicos { get; set; }
}