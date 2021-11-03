using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IWriterService: IGenericService<Writer>
    {
    
        List<Writer> GetBlogById(int id);
        List<Writer> GetWriterById(int id); //Include metodu kullanımı için yazar göre listeleme


    }
}
