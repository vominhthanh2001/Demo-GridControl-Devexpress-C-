using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public interface IGridProperties<TModel>
    {
        List<TModel> Rows { get; }
        List<TModel> RowSelected { get; }
        TModel RowSelect { get; }
        int Count { get; }
    }
}
