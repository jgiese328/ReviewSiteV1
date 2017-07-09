using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewSiteV1.Models
{
    public class Review
    {
        //Primary Key
        public int Id { get; set; }
        [Required]
        public string ReviewType { get; set; }
        [Required]
        public DateTime ?PublishDate { get; set; } // = DateTime.Now;  This would be if I wanted to hardcode 
        [Required]
        public string ReviewHeader { get; set; }
        [Required]
        public string ReviewText { get; set; }
        //[Required] -- not requiring across board due to edit 
        public Image Image { get; set; }
    }
}