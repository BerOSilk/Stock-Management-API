using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock{

    public class UpdateStockRequestDto{
        [Required]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(15, ErrorMessage = "Company name can not be over 15 characters!")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        public decimal Purchase { get; set; }
        [Required]
        public decimal LastDiv { get; set; }
        [Required]
        public string Industry { get; set; } = string.Empty;
        [Required]
        public long MarketCap { get; set; }
    }

}