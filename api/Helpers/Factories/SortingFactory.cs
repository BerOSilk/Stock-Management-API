using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.Factories{

    public class SortingFactory
    {
        public static IStockSort? GetSortingOption(string sortBy)
        {
            sortBy = sortBy.ToUpper();
            switch(sortBy){
                case "Symbol":
                    return new SymbolOption(null);
                case "COMPANYNAME":
                    return new CommpanyNameOption(null);
                case "INDUSTRY":
                    return new IndustryOption(null);
                default:
                    return null;
            }
        }
    }

}