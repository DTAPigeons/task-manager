using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess {
    class ScreenShotRepository {
        private TaskManagerEntities context;
        private DbSet<Screenshots> entities;

        public ScreenShotRepository() {
            context = new TaskManagerEntities();
            entities = context.Set<Screenshots>();
        }

        public List<Screenshots> GetAll() {
            return entities.ToList();
        }

        public Screenshots GetById(int id) {
            return entities.Where(entity => entity.ScreenshotId == id).FirstOrDefault();
        }

        public void Save(Screenshots screenShot) {
            if (screenShot.ScreenshotId <= 0) {
                Insert(screenShot);
            }
            else {
                Update(screenShot);
            }

            context.SaveChanges();
        }

        public void Insert(Screenshots screenShot) {
            entities.Add(screenShot);
        }

        public void Update(Screenshots screenShot) {
            context.Entry(screenShot).State = EntityState.Modified;
        }

        public void Delete(Screenshots screenShot) {
            entities.Remove(screenShot);
            context.SaveChanges();
        }
    }
}
