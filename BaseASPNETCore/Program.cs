using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();     //Agregar
builder.Services.AddSwaggerGen();              //agregar

// Add Datbabase Context
/*
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});
*/

var app = builder.Build();

/*
using (var scope = app.Services.CreateScope())  // verifucar si exite el base de datos
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Ensure the database is created
}
*/

app.UseSwagger(); 
app.UseSwaggerUI(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();