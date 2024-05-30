using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers
{
    public static class ViewUserMessages
    {
        public const string EditMessage = "Page for edit user";
        public const string AddMessage = "Page for add the user";
        public const string DeleteMessage = "Page for delete the user";
    }
    public static class ViewHomeMessages
    {
        public const string AboutMessage = "Your application description page.";
        public const string ContactMessage = "Your contact page.";
        public const string UserCrudOperationsMessage = "Page for crud operations with user";
        public const string UserRedirectUrl = "https://localhost:44374/User/User";
    }
}