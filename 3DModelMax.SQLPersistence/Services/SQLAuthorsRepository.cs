using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.SQLPersistence.Services
{
    public class SQLAuthorsRepository : IAuthorRepository<Author>
    {
        private AddDbContext db;

        public SQLAuthorsRepository(AddDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<Author>> GetAuthorsList()
        {
            return await db.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<Author> GetAuthById(int id)
        {
            return await db.Authors.AsNoTracking().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteAuthById(int id)
        {
            Author author = await db.Authors.FindAsync(id);

            if (author != null)
            {
                db.Authors.Remove(author);
            }
        }

        public async Task CreateAuth(Author author)
        {
            await db.Authors.AddAsync(author);
        }

        public void UpdateAuth(Author author)
        {
            db.Authors.Update(author);
        }

        public async Task SaveAuth()
        {
            await db.SaveChangesAsync();
        }
    }
}
