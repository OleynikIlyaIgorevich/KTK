var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DbContext, AuthDbContext>();
builder.Services.AddDatabase(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();