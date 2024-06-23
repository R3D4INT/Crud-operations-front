namespace WebApplication1.Helpers
{
    public static class ApiRoutes
    {
        public const string BaseUrl = "https://localhost:7110/api/UserApi";
        public const string GetAllUsers = BaseUrl + "/GetAllUsers";
        public const string UpdateUser = BaseUrl + "/UpdateUser/";
        public const string CreateUser = BaseUrl + "/CreateUser";
        public const string DeleteUser = BaseUrl + "/DeleteUser/";
        public const string GetUser = BaseUrl + "/GetUser/";
        public const string GetCountries = BaseUrl + "/GetCountries";
        public const string GetCountry = BaseUrl + "/GetCountry/";
    }
}