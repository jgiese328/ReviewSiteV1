using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSiteV1.Models
{
    public class Review
    {
        public int Id { get; set; }
        // [MaxLength: 100]
        public string ReviewType { get; set; }
        public DateTime PublishDate = DateTime.Now;
        public string ReviewHeader { get; set; }
        public string ReviewText { get; set; }
        public virtual ICollection<Image> Image { get; set; }
    }
}