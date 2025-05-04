using TyreManagement.API.Middleware;
using TyreManagement.Core;
using TyreManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Inject core servcies
builder.Services.AddCoreServices();
// Inject infrastructure servcies
builder.Services.AddPersistenceServices(builder.Configuration);

// Add controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add CORS
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(builder => {
    builder.AllowAnyOrigin() // Replace this with builder.WithOrigins("xxxx")
    .AllowAnyMethod()
    .AllowAnyHeader();
  });
});

// Build the app
var app = builder.Build();

// Middleware
app.UseExceptionHandlingMiddleware();

// Routing 
app.UseRouting();

// Swagger
app.UseSwagger(); //Adds endpoint that can serve the swagger.json
app.UseSwaggerUI(); //Adds swagger UI (interactive page to explore and test API endpoints)

// CORS
app.UseCors();

// Authentication
app.UseAuthentication();
app.UseAuthorization();

// Controller routes:
app.MapControllers();

app.Run();
