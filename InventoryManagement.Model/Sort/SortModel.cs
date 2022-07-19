using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.Sort
{
    public class SortModel
    {
        private string UpIcon = "fa fa-arrow-up";
        private string DownIcon = "fa fa-arrow-down";
        public string SortedProperty { get; set; }
        public SortOrder SortedOrder { get; set; }

        private List<SortableColumn> sortableColums = new List<SortableColumn>();
        public void AddColumn(string colname, bool IsDefaultColumn = false)
        {
            SortableColumn tmp = sortableColums.Where(c => c.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColums.Add(new SortableColumn() { ColumnName = colname });

            if (IsDefaultColumn == true || sortableColums.Count == 1)
            {
                SortedProperty = colname;
                SortedOrder = SortOrder.Ascending;
            }
        }

        public SortableColumn GetColumn(string colname)
        {
            SortableColumn tmp = sortableColums.Where(c => c.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColums.Add(new SortableColumn() { ColumnName = colname });
            return tmp;
        }
        public void ApplySort(string sortExpression)
        {
            if (sortExpression == "")
                sortExpression = SortedProperty;

            sortExpression = sortExpression.ToLower();

            foreach (SortableColumn sortableColumn in sortableColums)
            {
                sortableColumn.SortIcon = "";
                sortableColumn.SortExpression = sortableColumn.ColumnName;

                if (sortExpression == sortableColumn.ColumnName.ToLower())
                {
                    SortedOrder = SortOrder.Ascending;
                    SortedProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = DownIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName + "_desc";
                }

                if (sortExpression == sortableColumn.ColumnName.ToLower() + "_desc")
                {
                    SortedOrder = SortOrder.Descending;
                    SortedProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = UpIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName;
                }
            }
        }
        public class SortableColumn
        {
            public string ColumnName { get; set; }
            public string SortExpression { get; set; }
            public string SortIcon { get; set; }
        }
    }
}
