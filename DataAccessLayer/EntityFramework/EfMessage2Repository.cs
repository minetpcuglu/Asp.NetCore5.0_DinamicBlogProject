using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
   public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInboxWithMessageByWriter(int id)
        {
            using (var c = new Context()) 
            {
                return c.Message2s.Include(x => x.ReceiverUser).Where(x => x.SenderId == id).ToList();
            }
        }

        public List<Message2> GetSendBoxWithMessageByWriter(int id) //kategoriye göre yazar getirme
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList(); //gelen mesajlar //alıcı olduk
            }
        }

     
    }
}
