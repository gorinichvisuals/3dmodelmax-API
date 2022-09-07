using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Web;


namespace _3DModelMax.Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthorRepository<Author> _authorRepository;
        private readonly IConfiguration _configuration;

        public AuthenticateService(IAuthorRepository<Author> authorRepository, IConfiguration configuration)
        {
            _authorRepository = authorRepository;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDTO authorRequest)
        {
            var author = await _authorRepository.GetAuthor(authorRequest.NickName);

            if (author != null)
            {
                var token = GenerateToken(author);

                return token;
            }

            return null;
        }

        private string GenerateToken(Author author)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, author.NickName),
                new Claim(ClaimTypes.Name, author.FirstName),
                new Claim(ClaimTypes.Surname, author.LastName),
                new Claim(ClaimTypes.Email, author.Email),
                new Claim(ClaimTypes.Role, author.Role)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credintials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
