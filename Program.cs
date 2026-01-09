using ExamenCsharp.Repositories.Implementations;
using ExamenCsharp.Repositories.Interfaces;
using ExamenCsharp.Services.Implementations;
using ExamenCsharp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Injection de dépendances - Repositories
builder.Services.AddSingleton<IInscriptionRepository, InscriptionRepository>();
builder.Services.AddSingleton<IClasseRepository, ClasseRepository>();
builder.Services.AddSingleton<IAnneeScolaireRepository, AnneeScolaireRepository>();

// Injection de dépendances - Services
builder.Services.AddScoped<IInscriptionService, InscriptionService>();
builder.Services.AddScoped<IClasseService, ClasseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inscription}/{action=Enregistrer}/{id?}")
    .WithStaticAssets();


app.Run();
