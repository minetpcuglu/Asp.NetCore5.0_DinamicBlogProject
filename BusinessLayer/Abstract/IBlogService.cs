using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IBlogService:IGenericService<Blog>
    {
  
     
        List<Blog> GetBlogById(int id);
       
   
        List<Blog> GetBlogListWithCategory(); //Include metodu kullanımı için kategoriye göre listeleme
        List<Blog> GetBlogListByWriter(int id); //Include metodu kullanımı için yazar göre listeleme
    }
}
