using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Models
{
    public class WriterAndCityVM
    {
        public List<CitiesVM> CitiesVMs { get; set; }
        
        public List<Writer> Writers { get; set; }
    }
}
