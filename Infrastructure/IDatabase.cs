using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IDatabase<T>
    {
        bool CreateItem(T item);
        DataTable ReadItems();
        bool UpdateItem(T item);
        bool DeleteItem(T item);
    }
}
