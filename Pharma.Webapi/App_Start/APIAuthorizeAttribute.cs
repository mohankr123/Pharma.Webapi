using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Pharma.Webapi
{
    public class APIAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Forbidden);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                if (!string.IsNullOrEmpty(authenticationToken))
                {
                    if (authenticationToken == "asd")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}