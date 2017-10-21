using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class AddPostViewModel
    {
        public int? PostId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body is required")]
        [MaxLength(5000)]
        [DataType(DataType.Html, ErrorMessage = "Body is not valid HTML")]
        public string Body { get; set; }

        //[Required(ErrorMessage = "Created Date is required")]
        public System.DateTime CreatedDate { get; set; }

        //[Required(ErrorMessage = "Created By is required")]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public Nullable<System.DateTime> LastUpdatedDate { get; set; }

        [MaxLength(100)]
        public string LastUpdatedBy { get; set; }
        
    }
}
