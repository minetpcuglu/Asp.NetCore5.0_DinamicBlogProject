using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class BlogRayting
    {
        [Key]
        public int RaytingId { get; set; }
        public int BlogId { get; set; }
        public int BlogTotelScore { get; set; }
        public int BlogRaytingCount { get; set; }
    }
}
