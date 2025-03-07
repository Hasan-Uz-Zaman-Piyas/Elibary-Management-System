﻿using InventoryManagement.Data;
using InventoryManagement.Model;
using InventoryManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.Repositories
{
    public class UnitRepoisitory : IUnit
    {

        private readonly InventoryContext _context;
        public UnitRepoisitory(InventoryContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.Attach(unit);
            _context.Entry(unit).State = EntityState.Deleted;
            _context.SaveChanges();
            return unit;
        }

        public Unit Edit(Unit unit)
        {
            _context.Attach(unit);
            _context.Entry(unit).State = EntityState.Modified;
            _context.SaveChanges();
            return unit;
        }

        public List<Unit> GetItems(string ShortProperty, SortOrder sortOrder)
        {
            List<Unit> units = _context.Units.ToList();


            if (ShortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(n => n.Name).ToList();
                else
                    units = units.OrderByDescending(n => n.Name).ToList();

            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(d => d.Description).ToList();
                else
                    units = units.OrderByDescending(d => d.Description).ToList();

            }

            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }
    }
}
