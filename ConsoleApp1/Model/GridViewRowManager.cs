using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class GridViewRowManager : GridView<RowModel>
    {
        public GridViewRowManager(GridControl gc, GridView gv) : base(gc, gv)
        {
        }
    }
}
