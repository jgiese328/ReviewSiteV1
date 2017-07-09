using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ReviewSiteV1.Models
{
    public enum ReviewType
    {
        [Description("Anime")]
        Anime,
        [Description("Anime")]
        Game,
        [Description("Anime")]
        Movie
    }
}