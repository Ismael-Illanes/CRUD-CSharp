using AbbyWeb.Data;
using Microsoft.EntityFrameworkCore;
//PARA MIGRAR DB A SQLSERVER SE REQUIERE EF TOOLS Y EL COMANDO add-migration AddCategoryToDB , LUEGO USAR update-database
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// AQUI AGREGAMOS EL CONTEXT DE LA DB EN GENERAL A LA APP
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
