using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository<Author> _repository;

        public AuthorService(IAuthorRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task CreateAuthor(AuthorCreateDTO author)
        {
            var createAuthor = new Author();

            createAuthor.FirstName = author.FirstName;
            createAuthor.LastName = author.LastName;
            createAuthor.NickName = author.NickName;
            createAuthor.Age = author.Age;
            createAuthor.Description = author.Description;
            createAuthor.RegistrationDate = DateTime.Now;
            createAuthor.Email = author.Email;
            createAuthor.Password = author.Password;

            await _repository.CreateAuth(createAuthor);
            await _repository.SaveAuth();
        }
    }
}
