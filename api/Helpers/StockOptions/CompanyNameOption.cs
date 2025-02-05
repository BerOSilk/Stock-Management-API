using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.Factories{

    public class CommpanyNameOption : IStockSort, IStockFilter
    {
        private  readonly string? _companyName;
        public CommpanyNameOption(string? ComapnyName){
            _companyName = ComapnyName;
        }
        public IQueryable<Stock> ApplyFiltering(IQueryable<Stock> stocks)
        {
            return stocks.Where(s => s.Symbol == _companyName);
        }

        public IOrderedQueryable<Stock> ApplySorting(IQueryable<Stock> stocks, bool Descending){
            return Descending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName);
        }
    }

}