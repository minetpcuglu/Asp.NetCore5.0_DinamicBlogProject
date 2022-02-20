using BlogApiDemo.DataAccessLayer.Repository.BaseRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer.Repository.EntityTypeRepository.Interface
{
    public interface IEmployeeRepository : IBaseRepositories<Employee>
    {
    }
}
