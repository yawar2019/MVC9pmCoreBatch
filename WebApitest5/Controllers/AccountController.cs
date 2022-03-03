using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApitest5.Models;
using WebApitest5.Repository;

namespace WebApitest5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        { 
            var result = await _accountRepository.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginIn([FromBody] SignInModel signinModel)
        {
            var result = await _accountRepository.LoginInAsync(signinModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
                return Ok(result);

        }
    }
}
