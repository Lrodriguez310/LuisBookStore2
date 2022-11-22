using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuisBookStore.DataAccess.Data;
using LuisBooks.Models;
using LuisBooks.DataAccess.Repository.IRepository;

namespace LuisBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CoverType covertype = new CoverType();
            if (id == null)
            {
                return View(covertype);
            }

            covertype = (CoverType)_unitOfWork.CoverType.Get(id.GetValueOrDefault());
            if (covertype == null)
            {
                return NotFound(covertype);
            }
            return View(covertype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType covertype)
        {
            if (ModelState.IsValid)
            {
                if (covertype.Id == 0)
                {
                    _unitOfWork.CoverType.Add(covertype);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.CoverType.Update(covertype);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(covertype);

        }

        //Api calls
        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            //return NotFound
            var allObj = _unitOfWork.CoverType.GetAll();
            return Json(new { data = allObj });

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.CoverType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = true, message = "Erroe while Deleting" });
            }
            _unitOfWork.CoverType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
            #endregion
        }
    }
}
