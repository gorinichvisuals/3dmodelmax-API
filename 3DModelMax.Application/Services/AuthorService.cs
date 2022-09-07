using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository<Author> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IAuthorRepository<Author> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AuthorRegistration(AuthorRegistrationDTO author)
        {
            CreatePasswordHash(author.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var createAuthor = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                NickName = author.NickName,
                Age = author.Age,
                Description = author.Description,
                RegistrationDate = DateTime.Now,
                Email = author.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _repository.CreateAuthor(createAuthor);
            await _unitOfWork.Save();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
