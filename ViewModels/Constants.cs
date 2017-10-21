using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class Roles
    {
        public static string Admin = "Admin";
        public static string Editor = "Editor";
        public static string DefaultRole = "Editor";
    }
    public static class Errors
    {
        public static string ROLE_ASSIGNMENT = "Role assignment to the user is failed";
    }
    
    public static class Numbers
    {
        public static int PageSize=5;
    }

}
