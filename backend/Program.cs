 
using purrfect_olho_vivo_api.Configuration; 

var builder = WebApplication.CreateBuilder(args);

// Adicionar DbContexts ao contêiner
builder.Services.AddDbContexts(builder.Configuration);

// Adicionar serviços ao contêiner
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCustomCors();

var app = builder.Build();

app.UseCors("AllowLocalhost");

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar CORS antes de outros middlewares
app.UseCors("AllowLocalhost"); // Assegure-se de que o nome da política está correto

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
