using System;


public class Servicos 
{
    public Servicos( string nome, string descricao)  {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Descricao = descricao;
    }

    public Servicos(){}

    public string Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }


}