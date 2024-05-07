using BACK.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

List<Servicos> servicos = new List<Servicos>();

app.MapPost("servicos/cadastrar", ([FromBody] Servicos servico, [FromServices] AppContext context) => 
{
    Servicos? servicoExistente = context.Servicos.FirstOrDefault(s => s.Nome == servico.Nome);

    if(servicoExistente is null)
    {
        servico.Nome = servico.Nome.ToUpper();
        context.Servicos.Add(servico);
        context.SaveChanges();
        return Results.Ok(context.Servicos.ToList());

    }
    return Results.BadRequest("Serviço já cadastrado");
});

app.MapGet("servicos/listar", ([FromServices] AppContext context) => 

{
     if (context.Servicos.Any())
     
    {
        return Results.Ok(context.Servicos.ToList());
    }
    return Results.NotFound("Não existem serviços na tabela");

});

app.MapGet("servicos/buscar/{id}", ([FromServices] AppContext context, int id) => {
   Servicos? servicoBuascar = context.Servicos.FirstOrDefault(servico => servico.Id == id);
    
    if (servicoBuascar is null)
    {
    return Results.NotFound("Serviço não encontrado");

    }
    return Results.Ok(servicoBuascar);
   
});

app.MapDelete("servicos/deletar/{id}", ([FromServices] AppContext context, int id) => {
   Servicos? servicoBuascar = context.Servicos.Find(id);
    
    if (servicoBuascar is null)
    {
    return Results.NotFound("Serviço não encontrado");

    }
    context.Servicos.Remove(servicoBuascar);
    context.SaveChanges();
    return Results.Ok(servicoBuascar);
   
});

app.MapPut("servicos/atualizar/{id}", ([FromBody] Servicos servico, [FromServices] AppContext context, int id) => {
   Servicos? servicoBuascar = context.Servicos.Find(id);
    
    if (servicoBuascar is null)
    {
    return Results.NotFound("Serviço não encontrado");

    }
    servicoBuascar.Nome = servico.Nome.ToUpper();
    servicoBuascar.Descricao = servico.Descricao;
    context.SaveChanges();
    return Results.Ok(servicoBuascar);
   
});

app.Run();
