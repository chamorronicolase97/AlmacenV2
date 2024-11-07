using Entidades;
using Negocio;

var builder = WebApplication.CreateBuilder(args);

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazorCliente",
        policy =>
        {
            policy.WithOrigins("https://localhost:7106")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirBlazorCliente"); // Aplica la política de CORS

app.UseAuthorization();
app.MapControllers();
app.Run();
