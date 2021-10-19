using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface ICommentService: IGenericService<Comment>
    {
        //void Add(Comment comment);

        //void Delete(Blog blog);
        //void Update(Blog blog);
        List<Comment> GetList(int id);

        //List<Blog> GetBlogById(int id);

        //Blog GetById(int id);
        //List<Blog> GetBlogListWithCategory(); //Include metodu kullanımı için 
    }
}
