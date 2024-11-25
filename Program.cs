using Microsoft.EntityFrameworkCore;
using TareaWeb_9.Components;
using TareaWeb_9.Database;
using TareaWeb_9.Models;
using TareaWeb_9.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<GameDiaryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GameDiaryConnection")));

builder.Services.AddScoped<AuthService>(sp =>
    new AuthService(sp.GetRequiredService<IDbContextFactory<GameDiaryContext>>().CreateDbContext()));

builder.Services.AddScoped<ExperienceService>(sp =>
    new ExperienceService(sp.GetRequiredService<IDbContextFactory<GameDiaryContext>>().CreateDbContext()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();