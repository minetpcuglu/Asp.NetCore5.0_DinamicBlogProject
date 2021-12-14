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
    public class AdminManager : IGenericService<Admin>
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin t)
        {
            _adminDal.insert(t);
        }

        public void Delete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public Admin GetById(int id)
        {
           return _adminDal.GetById(id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.GetAll();
        }

        public void Update(Admin t)
        {
             _adminDal.Update(t);
        }
    }
}
