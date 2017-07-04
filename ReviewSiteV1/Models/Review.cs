using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSiteV1.Models
{
    public class Review
    { 
        // make sure it is generating auto-increment/ primary key
        public int Id { get; set; }
        // [MaxLength: 100]
        public string ReviewType { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public string ReviewHeader { get; set; }
        public string ReviewText { get; set; }
        public Image Image { get; set; }
    }
}