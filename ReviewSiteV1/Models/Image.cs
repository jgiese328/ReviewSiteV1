using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSiteV1.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
    }
}