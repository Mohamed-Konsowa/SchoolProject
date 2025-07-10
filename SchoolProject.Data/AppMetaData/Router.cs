
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
		}
		
	}
}
