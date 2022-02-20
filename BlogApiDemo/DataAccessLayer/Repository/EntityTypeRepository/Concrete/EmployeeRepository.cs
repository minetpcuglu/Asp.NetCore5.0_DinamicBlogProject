using BlogApiDemo.DataAccessLayer.Repository.BaseRepository.Concrete;
using BlogApiDemo.DataAccessLayer.Repository.EntityTypeRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer.Repository.EntityTypeRepository.Concrete
{
    public class EmployeeRepository : BaseRepositories<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context) { }
    }
}
