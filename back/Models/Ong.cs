namespace back.Models;

public class Ong
{
    public Ong(string nome, int cnpj, string endereco, string telefone, string email)
    {
        Nome = nome;
        Cnpj = cnpj;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
        RedesSociais = new List<RedeSocial>();
        Animais = new List<Animal>();
    }
   
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Cnpj { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public ICollection<RedeSocial> RedesSociais { get; set; }
    public ICollection<Animal> Animais { get; set; }
    
}