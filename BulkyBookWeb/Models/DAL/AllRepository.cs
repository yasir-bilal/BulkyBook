using System.Data.Entity;
using System.Collections.Generic;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace BulkyBookWeb.Models.DAL

{
    public class AllRepositroy : _IAllRepository
    {
        private readonly ApplicationDbContext _db;

        public AllRepositroy()
        {
            _db = new ApplicationDbContext();
        }

        public AllRepositroy(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
        public Category GetById(int CategoryID)
        {
            return _db.Categories.Find(CategoryID);
        }
        public void Insert(Category category)
        {
            _db.Categories.Add(category);
        }
        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
        public void Delete(int CategoryID)
        {
            Category category = _db.Categories.Find(CategoryID);
            _db.Categories.Remove(category);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

     

