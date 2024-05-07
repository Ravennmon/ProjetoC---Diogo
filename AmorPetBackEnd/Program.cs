using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppContext>();

var app = builder.Build();

List<Servicos> servicos = new List<Servicos>();

app.MapGet("/", () => "Hello World!");


app.MapPost("api/servicos/cadastrar", ([FromBody] Servicos servico, [FromServices] AppContext context) => {
    context.Servicos.Add(servico);
    context.SaveChanges();
    return Results.Created($"/api/servicos/{servico.Id}", servico);
});

app.Run();
