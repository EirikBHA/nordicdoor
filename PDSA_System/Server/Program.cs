using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PDSA_System.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

//Legger til autentisering skjemaer for JWT, og gir parametre for tokens
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        //ValidIssuer = "http://localhost:5000", trenger ikke dette enda
        //ValidAudience = "http://localhost:5000",
        //ValidateLifetime = true,
        ValidateIssuerSigningKey = false, //sett til false hvis ting ikke funker
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ED02457B5C41D964DBD2F2A609D63FE1BB7528DBE55E1ABF5B52C249CD735797")),

    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapGet("/ping2", () => "Hello World!").RequireAuthorization();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

//bruker autentisering og autorisering
app.UseAuthentication();
app.UseAuthorization();

app.Run();

/*
 * app.Run() kjøres i evig-loop til man avbryter.
 * For å teste tilkobling må du først kjøre prosjektet PDSA_System.Server og avbryte det slik at den fullfører resterende av filen.
 * Husk å bytte passord til ditt eget i appsettings.json filen.
 */

var test = new TestingDbConn();

test.TestConn();
