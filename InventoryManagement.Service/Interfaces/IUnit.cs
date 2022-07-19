using InventoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetItems(string ShortProperty, SortOrder sortOrder );// read all
        Unit GetUnit(int id); // read particular item
        Unit Create(Unit unit);
        Unit Edit(Unit unit);
        Unit Delete (Unit unit);
    }
}
