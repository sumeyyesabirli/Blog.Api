using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.RequestManager.Commands.Requests
{
    public class InsertPostCommandRequestModel
    {
        public string Title { get; set; }
        public string Context { get; set; }
        public string Sunmary { get; set; }
        public string UrlHandle { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public DateTime PulisDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
