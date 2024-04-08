using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject {
    public class GenericRepository<T> : IGenericRepository<T> where T : class {
        protected readonly HospitalManagementDBContext _context = null;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository() {
            _context = new HospitalManagementDBContext();
            _dbSet = _context.Set<T>();
        }
        public GenericRepository(HospitalManagementDBContext _context) {
            this._context = _context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() {
            return this._dbSet.ToList();
        }

        public T GetById(object id) {
            return this._dbSet.Find(id);
        }

        public void Insert(T entity) {
            this._dbSet.Add(entity);
            Save();
        }

        public void Update(T entity) {
            this._dbSet.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity) {
            T existing = this._dbSet.Find(entity);
            if (existing != null) {
                this._dbSet.Remove(existing);
                Save();
            }
        }

        public void Save() {
            this._context.SaveChanges();
        }
    }
}
