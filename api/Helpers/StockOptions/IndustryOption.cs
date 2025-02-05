using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.Factories{

    public class IndustryOption : IStockSort, IStockFilter
    {
        private  readonly string? _industry;
        public IndustryOption(string? Industry){
            _industry = Industry;
        }
        public IQueryable<Stock> ApplyFiltering(IQueryable<Stock> stocks)
        {
            return stocks.Where(s => s.Symbol == _industry);
        }

        public IOrderedQueryable<Stock> ApplySorting(IQueryable<Stock> stocks, bool Descending){
            return Descending ? stocks.OrderByDescending(s => s.Industry) : stocks.OrderBy(s => s.Industry);
        }
    }

}