using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers{

    public class QueryObject{
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? Industry { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool Descending { get; set; } = false;
    }

}