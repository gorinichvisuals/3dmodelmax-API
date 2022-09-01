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
    public class SQLImagesRepository : IImageRepository<Image>
    {
        private AddDbContext db;

        public SQLImagesRepository(AddDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<Image>> GetAllImages()
        {
            return await db.Images.AsNoTracking().ToListAsync();
        }

        public async Task AddImages(ICollection<Image> images)
        {
            await db.Images.AddAsync((Image) images);
        }

        public async Task<Image> GetImageById(int id)
        {
            return await db.Images.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteImagesById(int id)
        {
            Image image = await db.Images.FindAsync(id);

            if (image != null)
            {
                db.Images.Remove(image);
            }
        }

        public void UpdateImages(Image images)
        {
            db.Images.Update(images);
        }

        public async Task SaveImages()
        {
            await db.SaveChangesAsync();
        }
    }
}
