

public class Ongs
{
    public Ongs(string nome, int cnpj, string endereco, string telefone, string email, string redesSociais)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Cnpj = cnpj;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
        RedesSociais = redesSociais;
    }
   
    public Ongs(){}

    public string Id { get; set; }
    public string Nome { get; set; }
    public int Cnpj { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string RedesSociais { get; set; }

}