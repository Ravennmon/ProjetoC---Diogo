using BACK.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppContext>();

var app = builder.Build();

List<Servico> servicos = new List<Servico>();

app.MapPost("/tutores", ([FromBody] Tutor tutor, [FromServices] AppDbContext context) =>
{
    Tutor? tutorExistente = context.Tutores.FirstOrDefault(c => c.Nome == tutor.Nome);

    if (tutorExistente is null)
    {
        context.Tutores.Add(tutor);
        context.SaveChanges();
        return Results.Ok(context.Tutores.ToList());

    }
    return Results.BadRequest("Tutor já cadastrado");
});

app.MapGet("/tutores", ([FromServices] AppDbContext context) =>
{
    if (context.Tutores.Any())
    {
        return Results.Ok(context.Tutores.Include(p => p.Animais).ToList());
    }

    return Results.NotFound("Não existem tutores na tabela");
});

app.MapGet("/tutores/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Tutor? tutor = context.Tutores.Include(p => p.Animais).FirstOrDefault(tutor => tutor.Id == id);

    if (tutor is null)
    {
        return Results.NotFound("Tutor não encontrado");
    }



    return Results.Ok(tutor);

});

app.MapDelete("tutores/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Tutor? tutor = context.Tutores.Find(id);

    if (tutor is null)
    {
        return Results.NotFound("Tutor não encontrado");
    }

    context.Tutores.Remove(tutor);
    context.SaveChanges();
    return Results.Ok("Tutor removido com sucesso!");

});

app.MapPut("tutores/{id}", ([FromBody] Tutor tutorRequest, [FromServices] AppDbContext context, int id) =>
{
    Tutor? tutor = context.Tutores.Find(id);

    if (tutor is null)
    {
        return Results.NotFound("Tutor não encontrado");
    }

    tutor.Nome = tutorRequest.Nome;
    tutor.Endereco = tutorRequest.Endereco;
    tutor.Telefone = tutorRequest.Telefone;
    tutor.Email = tutorRequest.Email;
    tutor.CpfCnpj = tutorRequest.CpfCnpj;
    tutor.DataNascimento = tutorRequest.DataNascimento;
    context.SaveChanges();
    return Results.Ok(tutor);
});

app.MapPost("tutores/{id}/adocao/{animalId}", ([FromServices] AppDbContext context, int id, int animalId) =>
{
   Tutor? tutor = context.Tutores.Find(id);

    if (tutor is null)
    {
        return Results.NotFound("Tutor não encontrado");
    }

    Animal? animal = context.Animais.Find(animalId);

    if (animal is null)
    {
        return Results.NotFound("Animal não encontrado");
    }

    if (animal.Adotado)
    {
        return Results.BadRequest("Animal já adotado");
    }

    animal.Tutor = tutor;
    context.SaveChanges();
    return Results.Ok("Animal adotado com sucesso!");
});

app.MapGet("/animais", ([FromServices] AppDbContext context) =>
{
    if (context.Animais.Any())
    {
        return Results.Ok(context.Animais.ToList());
    }

    return Results.NotFound("Não existem animais na tabela");
});


app.MapGet("/animais/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Animal? animal = context.Animais.FirstOrDefault(animal => animal.Id == id);

    if (animal is null)
    {
        return Results.NotFound("Animal não encontrado");
    }

    return Results.Ok(animal);
});

app.MapDelete("animais/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Animal? animal = context.Animais.Find(id);

    if (animal is null)
    {
        return Results.NotFound("Animal não encontrado");
    }

    if (animal.Adotado)
    {
        return Results.BadRequest("Animal não pode ser removido pois já foi adotado");
    }

    context.Animais.Remove(animal);
    context.SaveChanges();
    return Results.Ok("Animal removido com sucesso!");

});

app.MapPut("animais/{id}", ([FromBody] Animal animalRequest, [FromServices] AppDbContext context, int id) =>
{
    Animal? animal = context.Animais.Find(id);

    if (animal is null)
    {
        return Results.NotFound("Animal não encontrado");
    }

    animal.Nome = animalRequest.Nome;
    animal.Tipo = animalRequest.Tipo;
    animal.DataNascimento = animalRequest.DataNascimento;
    animal.Raca = animalRequest.Raca;
    animal.Porte = animalRequest.Porte;
    animal.Peso = animalRequest.Peso;
    animal.Sexo = animalRequest.Sexo;
    animal.Observacao = animalRequest.Observacao;
    
    context.SaveChanges();
    return Results.Ok(animal);
});

app.MapPost("animais/{id}/fotos", ([FromServices] AppDbContext context, int id, [FromBody] AnimalFoto animalFoto ) =>
{
    Animal? animal = context.Animais.Find(id);

    if (animal is null)
    {
        return Results.NotFound("Animal não encontrado");
    }

    animalFoto.AnimalId = id;
    context.AnimalFotos.Add(animalFoto);
    context.SaveChanges();
    return Results.Ok(animal);
});

app.MapDelete("animais/fotos/{id}", ([FromServices] AppDbContext context, int id) =>
{
    AnimalFoto? animalFoto = context.AnimalFotos.Find(id);

    if (animalFoto is null)
    {
        return Results.NotFound("Foto não encontrada");
    }

    context.AnimalFotos.Remove(animalFoto);
    context.SaveChanges();
    return Results.Ok("Foto removida com sucesso!");

});

app.MapGet("/servicos", ([FromServices] AppDbContext context) =>
{
    if (context.Servicos.Any())
    {
        return Results.Ok(context.Servicos.Include(p => p.Ong).ToList());
    }

    return Results.NotFound("Não existem serviços na tabela");
});

app.MapGet("/servicos/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Servico? servico = context.Servicos.Include(p => p.Ong).FirstOrDefault(servico => servico.Id == id);

    if (servico is null)
    {
        return Results.NotFound("Serviço não encontrado");
    }

    return Results.Ok(servico);
});

app.MapPut("servicos/{id}", ([FromBody] Servico servicoRequest, [FromServices] AppDbContext context, int id) =>
{
    Servico? servico = context.Servicos.Find(id);

    if (servico is null)
    {
        return Results.NotFound("Serviço não encontrado");
    }

    servico.Nome = servicoRequest.Nome;
    servico.Descricao = servicoRequest.Descricao;
    context.SaveChanges();
    return Results.Ok(servico);
});


app.MapDelete("servicos/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Servico? servico = context.Servicos.Find(id);

    if (servico is null)
    {
        return Results.NotFound("Serviço não encontrado");
    }

    context.Servicos.Remove(servico);
    context.SaveChanges();
    return Results.Ok("Serviço removido com sucesso!");

});

app.Run();
