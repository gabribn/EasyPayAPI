using ApiProdutos.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyMethod()  
              .AllowAnyHeader(); 
    });
});

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=produtos.db"));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
        .AddControllers()
        .AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        );


    var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors("AllowAll");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    DbInitializer.Seed(db);
}

app.Run();


