using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Application.Interfaces
{
    public interface IAuthorService
    {
        Task CreateAuthor(AuthorCreateDTO author);
    }
}
