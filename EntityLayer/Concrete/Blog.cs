using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }  //küçük resim
        public string BlogImage { get; set; }  //Büyük resim
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }

        /*İlişkiler*/
        public int CategoryId { get; set; }
        public virtual Category  Category { get; set; }

        /*İlişkiler*/
        public List<Comment> Comments { get; set; }

        /*İlişkiler*/
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
