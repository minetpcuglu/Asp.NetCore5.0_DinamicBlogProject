using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }
        public void Add(Message2 t)
        {
            _message2Dal.insert(t);
        }

        public void Delete(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public Message2 GetById(int id)
        {
            return _message2Dal.GetById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)  //alıcı mesaj
        {
            return _message2Dal.GetInboxWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return _message2Dal.GetAll();
        }

        public List<Message2> GetSendboxListByWriter(int id)
        {
            return _message2Dal.GetSendBoxWithMessageByWriter(id);
        }

        public void Update(Message2 t)
        {
            _message2Dal.Update(t);
        }
    }
}
