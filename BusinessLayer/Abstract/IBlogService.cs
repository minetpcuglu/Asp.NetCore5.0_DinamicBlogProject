using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog );
        void Update(Blog blog);
        List<Blog> GetList();
        List<Blog> GetBlogById(int id);
       
        Blog GetById(int id);
        List<Blog> GetBlogListWithCategory(); //Include metodu kullanımı için kategoriye göre listeleme
        List<Blog> GetBlogListByWriter(int id); //Include metodu kullanımı için yazar göre listeleme
    }
}
