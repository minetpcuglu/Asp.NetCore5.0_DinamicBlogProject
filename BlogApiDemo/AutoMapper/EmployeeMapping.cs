using AutoMapper;
using BlogApiDemo.DataAccessLayer;
using BlogApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.AutoMapper
{
    public class EmployeeMapping:Profile
    {
        public EmployeeMapping()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();
        }
    }
}
