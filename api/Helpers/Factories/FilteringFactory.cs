using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.Factories{

    public class FilteringFactory
    {
        public static List<IStockFilter> GetStockFilteringOptions(QueryObject query)
        {
            List<IStockFilter> Specifications = new List<IStockFilter>();
            if(!string.IsNullOrWhiteSpace(query.Symbol)){
                Specifications.Add(new SymbolOption(query.Symbol));
            }
            if(!string.IsNullOrWhiteSpace(query.CompanyName)){
                Specifications.Add(new SymbolOption(query.CompanyName));
            }
            if(!string.IsNullOrWhiteSpace(query.Industry)){
                Specifications.Add(new SymbolOption(query.Industry));
            }
            return Specifications;
        }
    }

}