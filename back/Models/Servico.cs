
namespace back.Models;

using System.ComponentModel.DataAnnotations;

public class Servico
{
    public Servico(string nome, string descricao, int ongId)
    {
        Nome = nome;
        Descricao = descricao;
        OngId = ongId;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; }

    [MinLength(3)]
    [MaxLength(200)]
    public string? Descricao { get; set; }

    public int OngId { get; set; }
    public Ong? Ong { get; set; }
}