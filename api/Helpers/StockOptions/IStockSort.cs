using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.Factories{

    public interface IStockSort
    {
        public abstract IOrderedQueryable<Stock> ApplySorting(IQueryable<Stock> stocks, bool Descending);
    }

}