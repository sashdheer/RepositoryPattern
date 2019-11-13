using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RepositoryPattern.Models;
using RepositoryPattern.ViewModel;

namespace RepositoryPattern
{
    public static class AutoMapperConfig
    {
        public static  void RegisterAutoMapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Employee, EmployeeViewModel>();
            });
        }
    }
}