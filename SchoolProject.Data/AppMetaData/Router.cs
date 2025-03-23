using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        private const string SignleRoute = "/{id}";

        private const string Root = "Api";
        private const string Vergion = "v1";
        private const string Rule = Root + "/" + Vergion + "/";

        public static class Student
        {
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "/List";
            public const string GetById = Prefix + SignleRoute;
        }
    }
}
