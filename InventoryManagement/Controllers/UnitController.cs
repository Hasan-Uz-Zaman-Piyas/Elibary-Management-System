using InventoryManagement.Data;
using InventoryManagement.Model;
using InventoryManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index()
        {
            List<Unit> units = _unitRepo.GetItems();
            return View(units);
        }
 

        private readonly IUnit _unitRepo;
        public UnitController(IUnit unitrepo )
        {
            _unitRepo = unitrepo;
        }
        [HttpGet]
        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Unit unit)
        {
          unit = _unitRepo.Create(unit);
          return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }
      
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Unit units =_unitRepo.GetUnit(Id);
            return View(units);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
           unit = _unitRepo.Edit(unit);
           
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Unit unit)
        {
            unit = _unitRepo.Delete(unit);
            return RedirectToAction(nameof(Index));
        }
     
    }
}
