using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddDbContext<UserContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("UsersConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


//endpoints

app.MapGet("/users/{id}",async (IUserService userService, int id) =>{
    var user = await userService.GetUser(id);
    if (user == null){
        return Results.NotFound("No existe el usuario");
    }
    return Results.Ok(user);

});

app.MapGet("/users", async (IUserService userService) =>{
    var users = await userService.GetUsers();
    return Results.Ok(users);
});

app.MapPost("/users", async (IUserService userService, User user) =>{
    var exists = await userService.GetUser(user.userId);
    if (exists != null){
        return Results.Conflict("El user ya existe");
    }
    var operation = await userService.Add(user);
    if (operation == false){
        return Results.BadRequest("Hubo un error al agregar al user");
    }
    return Results.Created("User agregado exitosamente", user);

});


app.MapDelete("/users/{id}", async (IUserService userService, int id)=>{
    var exists = await userService.GetUser(id);
    if (exists == null){
        return Results.Conflict("El user no existe");
    }
    var operation = await userService.Delete(id);
     if (operation == false){
        return Results.BadRequest("Hubo un error al eliminar al user");
    }
    return Results.Ok("User eliminado exitosamente");


});



//ejecucion
app.Run();

