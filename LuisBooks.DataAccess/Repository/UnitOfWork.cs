using LuisBooks.DataAccess.Repository.IRepository;
using LuisBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuisBooks.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork    // make the method public to access the class
    {
        private readonly ApplicationDbContext _db;   // the using statement

        public UnitOfWork(ApplicationDbContext db) //constructor to use DI and inject in to the repositories
        {
            _db = db;
            Category = new CategoryRepository(_db);
            SP_Call = new SP_Call(_db);
        }
        public ICategoryRepository Category {get; private set;} //throw new NotImplementedException();

        public ISP_Call SP_Call { get; private set; } // throw new NotImplementedException();

        public void Dispose()
        {
            _db.Dispose(); 
        }

        public void Save()
        {
            _db.SaveChanges(); // all changes will be saved when the save method is called at the parent level
        }
    }
}
