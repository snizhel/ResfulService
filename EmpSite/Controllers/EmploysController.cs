using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using EmpSite.Models;

namespace EmpSite.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class EmploysController : ApiController
    {
        [HttpGet]
        [Route("api/employees")]
        public List<Employee> GetAll()
        {
            List<Employee> employees = new EmployDAO().SelectAll();
            return employees;
        }
        [HttpGet]
        [Route("api/employees/search/{keyword}")]
        public List<Employee> Search(string keyword)
        {
            List<Employee> employees = new EmployDAO().SelectByKeyword(keyword);
            return employees;
        }
        [HttpGet]
        [Route("api/employees/{ID}")]
        public Employee GetEmployee(int ID)
        {
            Employee employee = new EmployDAO().SelectByCode(ID);
            return employee;
        }
        [HttpPost]
        [Route("api/employees")]
        public bool Add(Employee employee)
        {
            bool res = new EmployDAO().Insert(employee);
            return res;
        }
        [HttpPut]
        [Route("api/employees/{ID}")]
        public bool Update(int ID,Employee employee)
        {
            if(ID!=employee.ID) return false;
            bool res = new EmployDAO().Update(employee);
            return res;
        }
        [HttpDelete]
        [Route("api/employees/{ID}")]
        public bool Delete(int ID)
        {
            bool res = new EmployDAO().Delete(ID);
            return res;
        }
    }
}