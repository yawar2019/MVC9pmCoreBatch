using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApitest5.Models;

namespace WebApitest5.Repository
{
    public interface IAccountRepository
    {
       public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        public Task<string> LoginInAsync(SignInModel signUpModel);

    }
}
