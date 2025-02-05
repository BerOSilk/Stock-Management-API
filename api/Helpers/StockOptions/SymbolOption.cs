using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.Factories{

    public class SymbolOption : IStockSort, IStockFilter
    {
        private  readonly string? _symbol;
        public SymbolOption(string? Symbol){
            _symbol = Symbol;
        }
        public IQueryable<Stock> ApplyFiltering(IQueryable<Stock> stocks)
        {
            return stocks.Where(s => s.Symbol == _symbol);
        }

        public IOrderedQueryable<Stock> ApplySorting(IQueryable<Stock> stocks, bool Descending){
            return Descending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
        }
    }

}