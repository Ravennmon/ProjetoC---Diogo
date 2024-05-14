namespace back.Models;

public class Cuidador
{
    public Cuidador(string nome, string email, string cpfCnpj, string telefone, string endereco, DateTime dataNascimento)  {
        Nome = nome;
        Email = email;
        CpfCnpj = cpfCnpj;
        Telefone = telefone;
        Endereco = endereco;
        DataNascimento = dataNascimento;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CpfCnpj { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Endereco { get; set; }
    public ICollection<RedeSocial> RedesSociais { get; set; }
    public ICollection<Animal> Animais { get; set; }
}