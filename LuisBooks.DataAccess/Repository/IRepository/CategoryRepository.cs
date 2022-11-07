using LuisBooks.DataAccess.Repository.IRepository;
using LuisBooks.Models;
using LuisBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuisBooks.DataAccess.Repository.IRepository
{
   public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }

    }
}
