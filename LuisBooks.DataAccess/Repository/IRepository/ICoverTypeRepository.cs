using LuisBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuisBooks.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType covertype);
    }
}
