using ADOWebApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using MySqlConnector;
using System.Configuration;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using BasicAuth.API.BasicAuth;

namespace ADOWebApiCRUD.Controllers
{
    //[BasicAuthenticationAttribute]

    public class ValuesController : ApiController
    {
        
            DAL DAL = null;
            public ValuesController()
            {
                DAL = new DAL();
            }


        // GET api/values
        
        public List<Employee> Get()
        {
            return (DAL.GetAllEmployees());
            
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            return (DAL.GetEmployee(id)); 
        }

        // POST api/values
        public string Post(Employee employee)
        {
            return (DAL.AddEmployee(employee));
        }

        // PUT api/values/5
        public string Put(int id,Employee employee)
        {
            return (DAL.UpdateEmployee(id,employee));
            
        }

        // DELETE api/values/5
        
        public string Delete(int id)
        {
            return (DAL.DeleteEmployee(id));
        }
    }
}
