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
            var createAuthor = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                NickName = author.NickName,
                Age = author.Age,
                Description = author.Description,
                RegistrationDate = DateTime.Now,
                Email = author.Email,
                Password = author.Password
            };

            await _repository.CreateAuthor(createAuthor);
            await _repository.SaveAuthor();
        }

        public async Task<IEnumerable<Author>> GetAuthorsList()
        {
            return await _repository.GetAuthorsList();
        }
    }
}
