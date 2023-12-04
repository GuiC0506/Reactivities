using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.MapControllers();


// "using": forces the garbagge collection to clean this scope
using var temporaryServiceScope = app.Services.CreateScope();
var servicesResolver = temporaryServiceScope.ServiceProvider;

try
{
    var temporaryDbContext = servicesResolver.GetRequiredService<DataContext>();
    await temporaryDbContext.Database.MigrateAsync();
    await Seed.SeedData(temporaryDbContext);
}
catch (Exception ex)
{
    var logger = servicesResolver.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Something went wrong during the migration process");
}
// from the memory after it's finished its role. It's a disposer
app.Run();