using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using PDSA_System.Server.Models;
using Dapper;

namespace PDSA_System.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    // login controller
    [HttpPost("login")]
    public IActionResult Login()
    {
        // Hente context fra POST-forespørsel
        var r = HttpContext.Request;
        
        var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connString = MyConfig.GetValue<string>("ConnectionStrings:DefaultConnection");

        using var connector = new DbHelper(connString);


        var brukernavn = r.Form["brukernavn"];
        var passord = r.Form["passord"];

        // Query user from database by username dapper
        //var user = connector.Connection.QueryFirstOrDefault<Bruker>("SELECT * FROM Users WHERE Epost = @Epost", new { brukernavn });

        //Console.WriteLine($"{user}");

        /*
        // check if the user is valid
        if (model.Username == "admin" && model.Password == "admin")
        {
            

            // return the token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        */
        // return unauthorized if the user is not valid
        return Unauthorized();
    }


}