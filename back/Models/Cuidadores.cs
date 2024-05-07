public class Cuidadores
{
    public Cuidadores(string nome, string endereco, string telefone, string email, string especialidade, int cpfCnpj, DateTime anoNasci)  {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
        Especialidade = especialidade;
        CpfCnpj = cpfCnpj;
        AnoNasci = anoNasci;
    }

    public Cuidadores(){}

    public string Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Especialidade { get; set; }
    public int CpfCnpj { get; set; }
    public DateTime AnoNasci { get; set; }
    
}