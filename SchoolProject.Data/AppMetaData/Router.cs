
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
            public const string Paginated = Prefix + "/Paginated";
            public const string GetById = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
        }

        public static class Department
        {
            public const string Prefix = Rule + "Department";
            public const string GetById = Prefix + "/Id";
        }
		public static class ApplicationUser
		{
			public const string Prefix = Rule + "User";
			public const string Create = Prefix + "/Create"; 
			public const string Paginated = Prefix + "/Paginated";
			public const string GetById = Prefix + SignleRoute;
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + SignleRoute;
            public const string ChangePassword = Prefix + "/Change-Password";
        }

        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/Refresh-Token";
            public const string ValidateToken = Prefix + "/Validate-Token";
        }

        public static class Authorization
        {
            public const string Prefix = Rule + "Authorization";
            public const string AddRole = Prefix + "/Role/Create";
        }
    }
}
