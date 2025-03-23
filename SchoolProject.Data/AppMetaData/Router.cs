﻿
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
            public const string Create = Prefix + "/Create";
        }
    }
}
