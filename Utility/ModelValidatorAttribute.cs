using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Utility
{
    //[AttributeUsage(AttributeTargets.Method)]
    public class ModelValidatorAttribute : ActionFilterAttribute
    {
        private readonly Type _model;
        public ModelValidatorAttribute(Type model)
        {
            _model = model;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object instance = Activator.CreateInstance(_model);

            MethodInfo methodSetValidator = _model.GetMethod("SetValidator");

            methodSetValidator.Invoke(instance,null);

            if (!filterContext.ModelState.IsValid)
            {

                filterContext.Result = new BadRequestObjectResult("Invalid Object");

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }


    //public static class ActionExecutedContextExtention
    //{
    //    public static void ValidateModelUsingFluent(this ActionExecutedContext actionExecutedContext)
    //    {

    //    }
    //}
}
