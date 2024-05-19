using back.Models;
using back.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/ongs", ([FromServices] AppDbContext context) =>
{
    List<Ong> ongs = context.Ongs.ToList();
    
    if (context.Ongs.Any())
    {
        return Results.Ok(ongs);
    }

    return Results.NotFound("Não existem ongs na tabela");
});

app.MapPost("/ongs", ([FromBody] Ong ong, [FromServices] AppDbContext context) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            ong,
            new ValidationContext(ong),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }
    
    Ong? ongExistente = context.Ongs.FirstOrDefault(o => o.Cnpj == ong.Cnpj);

    if (ongExistente is null)
    {
        ong.Nome = ong.Nome.ToUpper();
        context.Ongs.Add(ong);
        context.SaveChanges();
        return Results.Ok(ong);

    }
    return Results.BadRequest("Ong já cadastrada");
});

app.MapGet("/ongs/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Ong? ong = context.Ongs.FirstOrDefault(ong => ong.Id == id);

    if (ong is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    return Results.Ok(ong);

});

app.MapDelete("/ongs/{id}", ([FromServices] AppDbContext context, int id) =>
{
    Ong? ong = context.Ongs.Find(id);

    if (ong is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    context.Ongs.Remove(ong);
    context.SaveChanges();
    return Results.Ok("Ong removida com sucesso!");

});

app.MapPut("/ongs/{id}", ([FromBody] Ong ongRequest, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            ongRequest,
            new ValidationContext(ongRequest),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

    Ong? ong = context.Ongs.Find(id);

    if (ong is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    ong.Nome = ongRequest.Nome.ToUpper();
    ong.Cnpj = ongRequest.Cnpj;
    ong.Endereco = ongRequest.Endereco;
    ong.Telefone = ongRequest.Telefone;
    ong.Email = ongRequest.Email;
    context.SaveChanges();
    return Results.Ok(ong);
});

app.MapPost("/ongs/{id}/animais", ([FromBody] Animal animal, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            animal,
            new ValidationContext(animal),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

    Ong? ong = context.Ongs.Find(id);

    if (ong is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    animal.Ong = ong;
    context.Animais.Add(animal);
    context.SaveChanges();
    return Results.Ok(ong);
});

app.MapPost("/ongs/{id}/servicos", ([FromBody] Servico servico, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            servico,
            new ValidationContext(servico),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

    Ong? ong = context.Ongs.Find(id);

    if (ong is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    servico.Ong = ong;
    context.Servicos.Add(servico);
    context.SaveChanges();
    return Results.Ok(ong);
});

app.MapPost("/ongs/{id}/redes-sociais", ([FromBody] RedeSocial redeSocial, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            redeSocial,
            new ValidationContext(redeSocial),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

    Ong? ong = context.Ongs.Find(id);

    if (ong is null)
    {
        return Results.NotFound("Ong não encontrada");
    }

    redeSocial.Ong = ong;
    context.RedeSociais.Add(redeSocial);
    context.SaveChanges();
    return Results.Ok(ong);
});

app.MapPost("/tutores", ([FromBody] Tutor tutor, [FromServices] AppDbContext context) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            tutor,
            new ValidationContext(tutor),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

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

app.MapDelete("/tutores/{id}", ([FromServices] AppDbContext context, int id) =>
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

app.MapPut("/tutores/{id}", ([FromBody] Tutor tutorRequest, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            tutorRequest,
            new ValidationContext(tutorRequest),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

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

app.MapPost("/tutores/{id}/redes-sociais", ([FromBody] RedeSocial redeSocial, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            redeSocial,
            new ValidationContext(redeSocial),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

    Tutor? tutor = context.Tutores.Find(id);

    if (tutor is null)
    {
        return Results.NotFound("Tutor não encontrado");
    }

    redeSocial.Tutor = tutor;
    context.RedeSociais.Add(redeSocial);
    context.SaveChanges();
    return Results.Ok(tutor);
});

app.MapPost("/tutores/{id}/adocao/{animalId}", ([FromServices] AppDbContext context, int id, int animalId) =>
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

app.MapGet("/animais/tipo/{tipo}", ([FromServices] AppDbContext context, int tipo) =>
{
    TipoAnimal tipoAnimal = (TipoAnimal)tipo;

    List<Animal> animais = context.Animais.Where(a => a.Tipo == tipoAnimal).ToList();

    if (animais.Any())
    {
        return Results.Ok(animais);
    }

    return Results.NotFound("Não existem animais do tipo " + tipoAnimal + " na tabela");
});

app.MapDelete("/animais/{id}", ([FromServices] AppDbContext context, int id) =>
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

app.MapPut("/animais/{id}", ([FromBody] Animal animalRequest, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            animalRequest,
            new ValidationContext(animalRequest),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

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

app.MapPost("/animais/{id}/fotos", ([FromServices] AppDbContext context, int id, [FromBody] AnimalFoto animalFoto ) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            animalFoto,
            new ValidationContext(animalFoto),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

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

app.MapDelete("/animais/fotos/{id}", ([FromServices] AppDbContext context, int id) =>
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

app.MapPut("/servicos/{id}", ([FromBody] Servico servicoRequest, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            servicoRequest,
            new ValidationContext(servicoRequest),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

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


app.MapDelete("/servicos/{id}", ([FromServices] AppDbContext context, int id) =>
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

app.MapPut("/redes-sociais/{id}", ([FromBody] RedeSocial redeSocialRequest, [FromServices] AppDbContext context, int id) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();

    if (!Validator.TryValidateObject(
            redeSocialRequest,
            new ValidationContext(redeSocialRequest),
            erros,
            true
        )
    )
    {
        return Results.BadRequest(erros);
    }

    RedeSocial? redeSocial = context.RedeSociais.Find(id);

    if (redeSocial is null)
    {
        return Results.NotFound("Rede social não encontrada");
    }

    redeSocial.Url = redeSocialRequest.Url;
    redeSocial.Descricao = redeSocialRequest.Descricao;
    context.SaveChanges();
    return Results.Ok(redeSocial);
});

app.MapDelete("/redes-sociais/{id}", ([FromServices] AppDbContext context, int id) =>
{
    RedeSocial? redeSocial = context.RedeSociais.Find(id);

    if (redeSocial is null)
    {
        return Results.NotFound("Rede social não encontrada");
    }

    context.RedeSociais.Remove(redeSocial);
    context.SaveChanges();
    return Results.Ok("Rede social removida com sucesso!");

});

app.Run();
