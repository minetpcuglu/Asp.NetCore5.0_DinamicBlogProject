using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }  //küçük resim
        public string BlogImage { get; set; }  //Büyük resim
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
    }
}
