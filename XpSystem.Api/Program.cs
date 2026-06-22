using XpSystem; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<PlayerService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.MapControllers(); // PlayersController
app.Run();