using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Services.Utility
{
    public class CustomAuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        public CustomAuthorizationAttribute()
        {
            AuthenticationSchemes = "Bearer";

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            
           // we can read claims hear
           // throw new NotImplementedException();
        }
    }
}
