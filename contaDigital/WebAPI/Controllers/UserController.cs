//using Application.Application;
using Application.Interface;
using Entity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebAPI.Models;
using WebAPI.Token;
using Entity.Entity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUser _IAplicacaoUsuario;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IApplicationUser IAplicacaoUsuario, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _IAplicacaoUsuario = IAplicacaoUsuario;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/User/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Unauthorized();

            var result = await _IAplicacaoUsuario.CheckIfUserExists(login.email, login.password);
            if (result)
            {
                var idUser = await _IAplicacaoUsuario.ReturnIdUser(login.email);

                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                 .AddSubject("Empresa - Canal Dev Net Core")
                 .AddIssuer("Teste.Securiry.Bearer")
                 .AddAudience("Teste.Securiry.Bearer")
                 .AddClaim("idUser", idUser)
                 .AddExpiry(5) //Minutes
                 .Builder();

                return Ok(token.value);

            }
            else
            {
                return Unauthorized();
            }

        }


        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/SetUser")]
        public async Task<IActionResult> SetUser([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Ok("Falta alguns dados");

            var result = await
                _IAplicacaoUsuario.SetUser(login.email, login.password, login.age, login.phone);

            if (result)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return Ok("Erro ao adicionar usuário");
        }


        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateTokenIdentity")]
        public async Task<IActionResult> CreateTokenIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Unauthorized();

            var result = await
                _signInManager.PasswordSignInAsync(login.email, login.password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var idUser = await _IAplicacaoUsuario.ReturnIdUser(login.email);

                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                 .AddSubject("Empresa - Canal Dev Net Core")
                 .AddIssuer("Teste.Securiry.Bearer")
                 .AddAudience("Teste.Securiry.Bearer")
                 .AddClaim("idUser", idUser)
                 .AddExpiry(5) //Minutes
                 .Builder();

                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/SetUsuarioIdentity")]
        public async Task<IActionResult> SetUsuarioIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Ok("Falta alguns dados");

            try
            {
                var user = new ApplicationUser
                {
                    UserName = login.email,
                    Email = login.email,
                    Phone = login.phone,
                    Tipo = TypeUser.Comum,
                };
                var result = await _userManager.CreateAsync(user, login.password);

                if (result.Errors.Any())
                {
                    return Ok(result.Errors);
                }
                else
                {
                    return Ok("Usuário Adicionado com Sucesso");
                }

                // Geração de Confirmação caso precise
                //var userId = await _userManager.GetUserIdAsync(user);
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                // retorno email 
                //code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                //var result2 = await _userManager.ConfirmEmailAsync(user, code);

                //if (result2.Succeeded)
                //    return Ok("Usuário Adicionado com Sucesso");
                //else
                //    return Ok("Erro ao confirmar usuários");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
