public class Ongs
{
    public Ongs(string nome, int cnpj, string endereco, string telefone, string email, string redesSociais)
    {
        Nome = nome;
        Cnpj = cnpj;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
        RedesSociais = redesSociais;
    }
   
    public Ongs(){}

    public int Id { get; set; }
    public string Nome { get; set; }
    public int Cnpj { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string RedesSociais { get; set; }

}