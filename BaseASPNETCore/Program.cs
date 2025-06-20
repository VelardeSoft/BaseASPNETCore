using BaseASPNETCore.Shared.Domain.Repositories;
using BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Configuration;
using BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Repositories;
using BaseASPNETCore.User.Application.Internal.CommandServices;
using BaseASPNETCore.User.Application.Internal.QueryServices;
using BaseASPNETCore.User.Domain.Repositories;
using BaseASPNETCore.User.Domain.Services;
using BaseASPNETCore.User.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();     //Agregar
builder.Services.AddSwaggerGen();              //agregar

// Add Datbabase Context

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null) throw new Exception("Database connection string is not set.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandServices, UserCommandService>(); 
builder.Services.AddScoped<IUserQueryServices, UserQueryService>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())  // verifucar si exite el base de datos
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Ensure the database is created
}


app.UseSwagger(); 
app.UseSwaggerUI(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();