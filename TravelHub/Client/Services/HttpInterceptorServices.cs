using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace TravelHub.Client.Services
{
    public class HttpInterceptorServices
    {
        private readonly HttpClientInterceptor interceptor;
        private readonly NavigationManager navManager;

        public HttpInterceptorServices(HttpClientInterceptor interceptor, NavigationManager _navManager)
        {
            this.interceptor = interceptor;
            navManager = _navManager;
        }

        public void MonitorEvent() => interceptor.AfterSend += InterceptResponse;

        private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            string message = string.Empty;
            if (!e.Response.IsSuccessStatusCode)
            {
                var responseCode = e.Response.StatusCode;
                switch (responseCode)
                {
                    case HttpStatusCode.NotFound:
                        navManager.NavigateTo("/404");
                        message = "The requested resource was not found.";
                        break;
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                        navManager.NavigateTo("/unauthorized");
                        message = "You are not authorized to access this resource. ";
                        break;
                    default:
                        navManager.NavigateTo("/500");
                        message = "Something went wrong, please contact Administrator";break;
                }
            }
        }

        public void DisposeEvent() => interceptor.AfterSend -= InterceptResponse;
    }
}
