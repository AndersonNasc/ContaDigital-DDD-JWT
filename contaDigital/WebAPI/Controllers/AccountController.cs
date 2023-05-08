using Application.Interface;
using Entity.Entity;
using Entity.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IApplicationAccount _IApplicationAccount;

        public AccountController(IApplicationAccount IApplicationAccount)
        {
            _IApplicationAccount = IApplicationAccount;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListAccount")]
        public async Task<List<Account>> ListAcccount()
        {
            return await _IApplicationAccount.ListAccount();
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/SetAccountBalance")]
        public async Task<List<Validation>> SetAccountBalance(AccountModel accountModel)
        {
            var account = new Account();            
            account.Bank = accountModel.Bank;
            account.Agency = accountModel.Agency;
            account.NumberAccount = await NumberAccountGenerator();

            return account.Notifications;


        }

        private async Task<string> NumberAccountGenerator()
        {
            Random random = new Random();
            int account = random.Next(10000, 99999); // Gera um número aleatório entre 10000 e 99999

            //Verifica se a conta gerada existe 
            if(await _IApplicationAccount.CheckIfAccountExists(account.ToString()))
            {
                await this.NumberAccountGenerator();
            }

            return account.ToString();
        }
    }
}
