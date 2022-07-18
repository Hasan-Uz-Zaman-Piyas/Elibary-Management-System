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
        List<Unit> GetItems();
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);
        Unit Delete (Unit unit);
    }
}
