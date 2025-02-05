using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.Factories{

    public interface IStockFilter
    {
        public IQueryable<Stock> ApplyFiltering(IQueryable<Stock> stocks);
    }

}