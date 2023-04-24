using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public interface IGrid<TModel> : IGridProperties<TModel>
    {
        
        void Insert(TModel model, int index);
        void Add(TModel model);
        void AddRange(List<TModel> models);
        void Remove(TModel model);
        void Clear();
        void RefreshDataSource();
    }
}
