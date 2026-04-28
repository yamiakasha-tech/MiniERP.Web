using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniERP.Web.Components;
using MiniERP.Web.Data;
using MiniERP.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuracao completa do Identity com cookies.
builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProjetoService>();
builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<EmpregadoService>();
builder.Services.AddScoped<FaturaService>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Configuracao de perfis.
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "Financeiro", "Developer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var admin = await userManager.FindByEmailAsync("admin@erp.com");

    if (admin == null)
    {
        admin = new IdentityUser
        {
            UserName = "admin@erp.com",
            Email = "admin@erp.com"
        };

        await userManager.CreateAsync(admin, "Admin123!");
        await userManager.AddToRoleAsync(admin, "Admin");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Endpoint de login chamado por um POST normal do browser para permitir criar o cookie.
app.MapPost("/api/login", async (
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager,
    [FromForm] string email,
    [FromForm] string password) =>
{
    var user = await userManager.FindByEmailAsync(email);

    if (user == null)
    {
        return Results.LocalRedirect("/login?erro=1");
    }

    var result = await signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

    return result.Succeeded
        ? Results.LocalRedirect("/")
        : Results.LocalRedirect("/login?erro=1");
}).DisableAntiforgery();

// Endpoint de logout chamado pelo menu lateral.
app.MapPost("/api/logout", async (SignInManager<IdentityUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.LocalRedirect("/login");
}).DisableAntiforgery();

app.Run();
