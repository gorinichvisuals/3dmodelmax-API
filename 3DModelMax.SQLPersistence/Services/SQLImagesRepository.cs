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

        public async Task AddImages(ICollection<Image> images)
        {
            await db.Images.AddRangeAsync(images);
        }

        public async Task DeleteImageById(int id)
        {
            Image? image = await db.Images.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

            if (image != null)
            {
                db.Images.Remove(image);
            }
        }

        public void UpdateImages(Image images)
        {
            db.Images.Update(images);
        }       
    }
}
