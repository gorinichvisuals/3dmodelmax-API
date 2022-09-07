using _3DModelMax.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<string> Login(LoginDTO authorRequest);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}

