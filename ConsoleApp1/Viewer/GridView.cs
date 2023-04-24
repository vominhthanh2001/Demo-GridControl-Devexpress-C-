using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class GridView<TModel> : IGrid<TModel>
    {
        private readonly GridControl _gc;
        private readonly GridView _gv;
        private List<TModel> _rows { get; set; } = new List<TModel>();

        public GridView(GridControl gc, GridView gv)
        {
            this._gc = gc;
            this._gv = gv;
        }

        public List<TModel> Rows
        {
            get
            {
                return _rows;
            }
        }

        public List<TModel> RowSelected
        {
            get
            {
                int[] indexSelected = _gv.GetSelectedRows();
                return indexSelected.Select(index => _rows[index]).ToList();
            }
        }

        public TModel RowSelect
        {
            get
            {
                int indexSelect = _gv.GetSelectedRows().FirstOrDefault();
                return _rows[indexSelect];
            }
        }

        public int Count => _rows.Count;

        public void Add(TModel model)
        {
            _rows.Add(model);
            RefreshDataSource();
        }

        public void AddRange(List<TModel> models)
        {
            _rows.AddRange(models);
            RefreshDataSource();
        }

        public void Clear()
        {
            _rows.Clear();
            RefreshDataSource();
        }

        public void Insert(TModel model, int index)
        {
            _rows.Insert(index, model);
            RefreshDataSource();
        }

        public void Remove(TModel model)
        {
            _rows.Remove(model);
            RefreshDataSource();
        }

        public void RefreshDataSource()
        {
            _gc.DataSource = _rows;
            _gc.RefreshDataSource();
        }
    }
}
