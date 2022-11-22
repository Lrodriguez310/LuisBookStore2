using LuisBooks.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuisBookStore.DataAccess.Data;

namespace LuisBooks.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IProductRepository Product { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}




/*using LuisBooks.DataAccess.Repository.IRepository;
using LuisBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuisBooks.DataAccess.Repository
{ 
public class UnitOfWork : IUnitOfWork //make the method public to access the class
{
    private readonly ApplicationDbContext _db; //the using statement

    public UnitOfWork(ApplicationDbContext db) //Constructor to use DI and inject in to the repositories
    {
        _db = db;
        Category = new CategoryRepository(_db);
        SP_Call = new SP_Call(_db);
        CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
    }
    public ICategoryRepository Category { get; private set; }// throw new NotImplementedException();

    public ISP_Call SP_Call
    {
        get; private set; //throw new NotImplementedException();
    }

    public ICoverTypeRepository CoverType
    {
        get; private set;
    }
    public ProductRepository Product { get; private set; }
    public ICoverTypeRepository CoverTypeRePository => throw new NotImplementedException();

        IProductRepository IUnitOfWork.Product => throw new NotImplementedException();

        public void Dispose()
    {
        _db.Dispose();
    }

    *//* public ICategoryRepository GetCoverType()
     {
         throw new NotImplementedException();
     }
*//*
    public void Save()
    {
        _db.SaveChanges();  // All changes will be saved when the save method is called at the parent level
    }

    *//* public void save()
     {
         _db.SaveChanges();
        // throw new NotImplementedException();
     }*//*
}
    }
*/