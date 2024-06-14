using System;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                var errors = filterContext.Controller.ViewData.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                filterContext.Result = new JsonResult
                {
                    Data = new { success = false, errors = errors },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet 
                };

                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}