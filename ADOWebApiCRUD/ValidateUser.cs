

//using BasicAuth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth.API
{
    public class ValidateUser
    {
        
        public static bool Login(string username, string password)
        {
            if(username=="waseem" && password == "1234")
                return true;
            else return false;
        }

        
    }
}