using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Lapostemobile_projetrest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("AppDbConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ArticleRepository>();
builder.Services.AddScoped<AdresseRepository>();
builder.Services.AddScoped<CaracteristiquesArticleRepository>();
builder.Services.AddScoped<CoordonneesBancaireRepository>();
builder.Services.AddScoped<ModeLivraisonRepository>();
builder.Services.AddScoped<OffreEngagementRepository>();
builder.Services.AddScoped<PrixArticleRepository>();
builder.Services.AddScoped<ProspectRepository>();
builder.Services.AddScoped<SouscriptionRepository>();
builder.Services.AddScoped<StatutSouscriptionRepository>();
builder.Services.AddDbContext<PortailContext>(options => options.UseSqlServer(connString));
builder.Services.AddSingleton<MailService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseAuthorization();

app.MapControllers();

app.Run();
