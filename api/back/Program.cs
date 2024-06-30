using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using back.Models;
using back.Enums;
using back.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAllOrigin",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();

app.MapGet("/ongs", async ([FromServices] AppDbContext context) =>
{
    var ongs = await context.Ongs.ToListAsync();
    return ongs.Any() ? Results.Ok(ongs) : Results.NotFound("Não existem ongs na tabela");
});

app.MapPost("/ongs", async ([FromBody] Ong ong, [FromServices] AppDbContext context) =>
{
    var errors = ValidateModel(ong);
    if (errors.Any()) return Results.BadRequest(errors);

    if (await context.Ongs.AnyAsync(o => o.Cnpj == ong.Cnpj))
        return Results.BadRequest("Ong já cadastrada");

    ong.Nome = ong.Nome.ToUpper();
    context.Ongs.Add(ong);
    await context.SaveChangesAsync();
    return Results.Ok(ong);
});

app.MapGet("/ongs/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var ong = await context.Ongs.FindAsync(id);
    return ong is not null ? Results.Ok(ong) : Results.NotFound("Ong não encontrada");
});

app.MapDelete("/ongs/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var ong = await context.Ongs.FindAsync(id);
    if (ong is null) return Results.NotFound("Ong não encontrada");

    context.Ongs.Remove(ong);
    await context.SaveChangesAsync();
    return Results.Ok("Ong removida com sucesso!");
});

app.MapPut("/ongs/{id}", async ([FromBody] Ong ongRequest, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(ongRequest);
    if (errors.Any()) return Results.BadRequest(errors);

    var ong = await context.Ongs.FindAsync(id);
    if (ong is null) return Results.NotFound("Ong não encontrada");

    ong.Update(ongRequest, context);
    await context.SaveChangesAsync();
    return Results.Ok(ong);
});

app.MapPost("/ongs/{id}/animais", async ([FromBody] Animal animal, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(animal);
    if (errors.Any()) return Results.BadRequest(errors);

    var ong = await context.Ongs.FindAsync(id);
    if (ong is null) return Results.NotFound("Ong não encontrada");

    animal.Ong = ong;
    context.Animais.Add(animal);
    await context.SaveChangesAsync();
    return Results.Ok(ong);
});

app.MapPost("/ongs/{id}/servicos", async ([FromBody] Servico servico, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(servico);
    if (errors.Any()) return Results.BadRequest(errors);

    var ong = await context.Ongs.FindAsync(id);
    if (ong is null) return Results.NotFound("Ong não encontrada");

    servico.Ong = ong;
    context.Servicos.Add(servico);
    await context.SaveChangesAsync();
    return Results.Ok(ong);
});

app.MapPost("/ongs/{id}/redes-sociais", async ([FromBody] RedeSocial redeSocial, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(redeSocial);
    if (errors.Any()) return Results.BadRequest(errors);

    var ong = await context.Ongs.FindAsync(id);
    if (ong is null) return Results.NotFound("Ong não encontrada");

    redeSocial.Ong = ong;
    context.RedeSociais.Add(redeSocial);
    await context.SaveChangesAsync();
    return Results.Ok(ong);
});

app.MapPost("/tutores", async ([FromBody] Tutor tutor, [FromServices] AppDbContext context) =>
{
    var errors = ValidateModel(tutor);
    if (errors.Any()) return Results.BadRequest(errors);

    if (await context.Tutores.AnyAsync(t => t.Nome == tutor.Nome))
        return Results.BadRequest("Tutor já cadastrado");

    context.Tutores.Add(tutor);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Tutores.ToListAsync());
});

app.MapGet("/tutores", async ([FromServices] AppDbContext context) =>
{
    var tutores = await context.Tutores.Include(t => t.Animais).ToListAsync();
    return tutores.Any() ? Results.Ok(tutores) : Results.NotFound("Não existem tutores na tabela");
});

app.MapGet("/tutores/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var tutor = await context.Tutores.Include(t => t.Animais).FirstOrDefaultAsync(t => t.Id == id);
    return tutor is not null ? Results.Ok(tutor) : Results.NotFound("Tutor não encontrado");
});

app.MapDelete("/tutores/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var tutor = await context.Tutores.FindAsync(id);
    if (tutor is null) return Results.NotFound("Tutor não encontrado");

    context.Tutores.Remove(tutor);
    await context.SaveChangesAsync();
    return Results.Ok("Tutor removido com sucesso!");
});

app.MapPut("/tutores/{id}", async ([FromBody] Tutor tutorRequest, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(tutorRequest);
    if (errors.Any()) return Results.BadRequest(errors);

    var tutor = await context.Tutores.FindAsync(id);
    if (tutor is null) return Results.NotFound("Tutor não encontrado");

    tutor.Update(tutorRequest, context);
    await context.SaveChangesAsync();
    return Results.Ok(tutor);
});

app.MapPost("/tutores/{id}/redes-sociais", async ([FromBody] RedeSocial redeSocial, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(redeSocial);
    if (errors.Any()) return Results.BadRequest(errors);

    var tutor = await context.Tutores.FindAsync(id);
    if (tutor is null) return Results.NotFound("Tutor não encontrado");

    redeSocial.Tutor = tutor;
    context.RedeSociais.Add(redeSocial);
    await context.SaveChangesAsync();
    return Results.Ok(tutor);
});

app.MapPost("/tutores/{id}/adocao/{animalId}", async ([FromServices] AppDbContext context, int id, int animalId) =>
{
    var tutor = await context.Tutores.FindAsync(id);
    if (tutor is null) return Results.NotFound("Tutor não encontrado");

    var animal = await context.Animais.FindAsync(animalId);
    if (animal is null) return Results.NotFound("Animal não encontrado");

    if (animal.Adotado) return Results.BadRequest("Animal já adotado");

    animal.Tutor = tutor;
    await context.SaveChangesAsync();
    return Results.Ok("Animal adotado com sucesso!");
});

app.MapGet("/animais", async ([FromServices] AppDbContext context) =>
{
    var animais = await context.Animais.ToListAsync();
    return animais.Any() ? Results.Ok(animais) : Results.NotFound("Não existem animais na tabela");
});

app.MapGet("/animais/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var animal = await context.Animais.FindAsync(id);
    return animal is not null ? Results.Ok(animal) : Results.NotFound("Animal não encontrado");
});

app.MapGet("/animais/tipo/{tipo}", async ([FromServices] AppDbContext context, int tipo) =>
{
    var tipoAnimal = (TipoAnimal)tipo;
    var animais = await context.Animais.Where(a => a.Tipo == tipoAnimal).ToListAsync();
    return animais.Any() ? Results.Ok(animais) : Results.NotFound($"Não existem animais do tipo {tipoAnimal} na tabela");
});

app.MapDelete("/animais/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var animal = await context.Animais.FindAsync(id);
    if (animal is null) return Results.NotFound("Animal não encontrado");

    if (animal.Adotado) return Results.BadRequest("Animal já foi adotado e não pode ser excluído");

    context.Animais.Remove(animal);
    await context.SaveChangesAsync();
    return Results.Ok("Animal removido com sucesso!");
});

app.MapPut("/animais/{id}", async ([FromBody] Animal animalRequest, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(animalRequest);
    if (errors.Any()) return Results.BadRequest(errors);

    var animal = await context.Animais.FindAsync(id);
    if (animal is null) return Results.NotFound("Animal não encontrado");

    animal.Update(animalRequest, context);
    await context.SaveChangesAsync();
    return Results.Ok(animal);
});

app.MapPost("/animais/{id}/fotos", async ([FromBody] AnimalFoto animalFoto, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(animalFoto);
    if (errors.Any()) return Results.BadRequest(errors);

    var animal = await context.Animais.FindAsync(id);
    if (animal is null) return Results.NotFound("Animal não encontrado");

    animalFoto.AnimalId = id;
    context.AnimalFotos.Add(animalFoto);
    await context.SaveChangesAsync();
    return Results.Ok(animal);
});

app.MapDelete("/animais/fotos/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var animalFoto = await context.AnimalFotos.FindAsync(id);
    if (animalFoto is null) return Results.NotFound("Foto não encontrada");

    context.AnimalFotos.Remove(animalFoto);
    await context.SaveChangesAsync();
    return Results.Ok("Foto removida com sucesso!");
});

app.MapPut("/servicos/{id}", async ([FromBody] Servico servicoRequest, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(servicoRequest);
    if (errors.Any()) return Results.BadRequest(errors);

    var servico = await context.Servicos.FindAsync(id);
    if (servico is null) return Results.NotFound("Serviço não encontrado");

    servico.Update(servicoRequest, context);
    await context.SaveChangesAsync();
    return Results.Ok(servico);
});

app.MapDelete("/servicos/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var servico = await context.Servicos.FindAsync(id);
    if (servico is null) return Results.NotFound("Serviço não encontrado");

    context.Servicos.Remove(servico);
    await context.SaveChangesAsync();
    return Results.Ok("Serviço removido com sucesso!");
});

app.MapPut("/redes-sociais/{id}", async ([FromBody] RedeSocial redeSocialRequest, [FromServices] AppDbContext context, int id) =>
{
    var errors = ValidateModel(redeSocialRequest);
    if (errors.Any()) return Results.BadRequest(errors);

    var redeSocial = await context.RedeSociais.FindAsync(id);
    if (redeSocial is null) return Results.NotFound("Rede social não encontrada");

    redeSocial.Update(redeSocialRequest, context);
    await context.SaveChangesAsync();
    return Results.Ok(redeSocial);
});

app.MapDelete("/redes-sociais/{id}", async ([FromServices] AppDbContext context, int id) =>
{
    var redeSocial = await context.RedeSociais.FindAsync(id);
    if (redeSocial is null) return Results.NotFound("Rede social não encontrada");

    context.RedeSociais.Remove(redeSocial);
    await context.SaveChangesAsync();
    return Results.Ok("Rede social removida com sucesso!");
});

static List<ValidationResult> ValidateModel(object model)
{
    var validationResults = new List<ValidationResult>();
    Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);
    return validationResults;
}


app.Run();
app.UseCors("AllowAllOrigin");

