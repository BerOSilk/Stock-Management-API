using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock{

    public class UpdateCommentDto{       
        [Required]
        [MaxLength(30, ErrorMessage = "Comment Title cannot be over 30 characters!")]
         public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(280, ErrorMessage = "You have reached the maximum length of Comment Content Characters!!")]
        public string Content { get; set; } = string.Empty;
    }

}