using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess {
    class CompanyRepository {
        private TaskManagerEntities context;
        private DbSet<Company> entities;

        public CompanyRepository() {
            context = new TaskManagerEntities();
            entities = context.Set<Company>();
        }

        public List<Company> GetAll() {
            return entities.ToList();
        }

        public Company GetById(int id) {
            return entities.Where(entity => entity.CompanyId == id).FirstOrDefault();
        }

        public void Save(Company company) {
            if (company.CompanyId <= 0) {
                Insert(company);
            }
            else {
                Update(company);
            }

            context.SaveChanges();
        }

        public void Insert(Company company) {
            entities.Add(company);
        }

        public void Update(Company company) {
            context.Entry(company).State = EntityState.Modified;
        }

        public void Delete(Company company) {
            entities.Remove(company);
            context.SaveChanges();
        }
    }
}
