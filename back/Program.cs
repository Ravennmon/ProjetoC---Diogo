using back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

List<Servico> servicos = new List<Servico>();

app.MapPost("/ongs", ([FromBody] Ong ong, [FromServices] AppDbContext context) => 
{
    Ong? ongExistente = context.Ongs.FirstOrDefault(o => o.Nome == ong.Nome);

    if(ongExistente is null)
    {
        ong.Nome = ong.Nome.ToUpper();
        context.Ongs.Add(ong);
        context.SaveChanges();
        return Results.Ok(context.Ongs.ToList());

    }
    return Results.BadRequest("Ong já cadastrada");
});

app.MapGet("/ongs", ([FromServices] AppDbContext context) => 
{
    if (context.Ongs.Any())
    {
        return Results.Ok(context.Ongs.ToList());
    }

    return Results.NotFound("Não existem ongs na tabela");
});

app.MapGet("/ongs/{id}", ([FromServices] AppDbContext context, int id) => {
   Ong? ongBuascar = context.Ongs.FirstOrDefault(ong => ong.Id == id);
    
    if (ongBuascar is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    return Results.Ok(ongBuascar);
   
});

app.MapDelete("ongs/{id}", ([FromServices] AppDbContext context, int id) => {
   Ong? ongBuascar = context.Ongs.Find(id);
    
    if (ongBuascar is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    context.Ongs.Remove(ongBuascar);
    context.SaveChanges();
    return Results.Ok(ongBuascar);
   
});

app.MapPut("ongs/{id}", ([FromBody] Ong ong, [FromServices] AppDbContext context, int id) => {
    Ong? ongBuascar = context.Ongs.Find(id);
    
    if (ongBuascar is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    ongBuascar.Nome = ong.Nome.ToUpper();
    ongBuascar.Cnpj = ong.Cnpj;
    ongBuascar.Endereco = ong.Endereco;
    ongBuascar.Telefone = ong.Telefone;
    ongBuascar.Email = ong.Email;
    context.SaveChanges();
    return Results.Ok(ongBuascar);
});

app.MapPost("/cuidadores", ([FromBody] Cuidador cuidador, [FromServices] AppDbContext context) => 
{
    Cuidador? cuidadorExistente = context.Cuidadores.FirstOrDefault(c => c.Nome == cuidador.Nome);

    if(cuidadorExistente is null)
    {
        context.Cuidadores.Add(cuidador);
        context.SaveChanges();
        return Results.Ok(context.Cuidadores.ToList());

    }
    return Results.BadRequest("Cuidador já cadastrado");
});

app.MapGet("/cuidadores", ([FromServices] AppDbContext context) => 
{
    if (context.Cuidadores.Any())
    {
        return Results.Ok(context.Cuidadores.Include(p => p.Animais).ToList());
    }

    return Results.NotFound("Não existem cuidadores na tabela");
});

app.MapGet("/cuidadores/{id}", ([FromServices] AppDbContext context, int id) => {
   Cuidador? cuidador = context.Cuidadores.Include(p => p.Animais).FirstOrDefault(cuidador => cuidador.Id == id);
    
    if (cuidador is null)
    {
        return Results.NotFound("Cuidador não encontrado");
    }

    

    return Results.Ok(cuidador);
   
});

app.MapDelete("cuidadores/{id}", ([FromServices] AppDbContext context, int id) => {
   Cuidador? cuidador = context.Cuidadores.Find(id);
    
    if (cuidador is null)
    {
        return Results.NotFound("Cuidador não encontrado");
    }

    context.Cuidadores.Remove(cuidador);
    context.SaveChanges();
    return Results.Ok(cuidador);
   
});

app.MapPut("cuidadores/{id}", ([FromBody] Cuidador cuidadorRequest, [FromServices] AppDbContext context, int id) => {
    Cuidador? cuidador = context.Cuidadores.Find(id);
    
    if (cuidador is null)
    {
        return Results.NotFound("Cuidador não encontrado");
    }

    cuidador.Nome = cuidadorRequest.Nome;
    cuidador.Endereco = cuidadorRequest.Endereco;
    cuidador.Telefone = cuidadorRequest.Telefone;
    cuidador.Email = cuidadorRequest.Email;
    cuidador.CpfCnpj = cuidadorRequest.CpfCnpj;
    cuidador.DataNascimento = cuidadorRequest.DataNascimento;
    context.SaveChanges();
    return Results.Ok(cuidador);
});

app.MapPost("cuidadores/{id}/animal", ([FromBody] Animal animal, [FromServices] AppDbContext context, int id) => {
    Cuidador? cuidador = context.Cuidadores.Find(id);

    if (cuidador is null)
    {
        return Results.NotFound("Cuidador não encontrado");
    }

    animal.Cuidador = cuidador;
    context.Animais.Add(animal);
    context.SaveChanges();
    return Results.Ok(context.Animais.ToList());
});

app.MapPost("ongs/{id}/animais", ([FromBody] Animal animal, [FromServices] AppDbContext context, int id) => {
    Ong? ong = context.Ongs.Find(id);

    if (ong is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    animal.Ong = ong;
    context.Animais.Add(animal);
    context.SaveChanges();
    return Results.Ok(context.Animais.ToList());
});


app.Run();
