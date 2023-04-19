using BookApi.BookPublication;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BookPublicationService>();
builder.Services.Scan(scan => scan
    .FromAssemblyOf<BookPublicationService>()
    .AddClasses(classes => classes.AssignableTo(typeof(IBookPublicationStrategy<>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/publish", ([FromServices] BookPublicationService service)
    => Results.Ok(new
    {
        BookA = service.Upload(new BookA("Story time")),
        BookB = service.Upload(new BookB("Story time: part 2"))
    }))
.WithName("publish")
.WithOpenApi();

app.Run();
