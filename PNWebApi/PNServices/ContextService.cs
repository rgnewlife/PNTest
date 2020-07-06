using System;

using Microsoft.AspNetCore.Http;

namespace PNServices
{

    /// <summary>
    /// ContextService is a wrapper class that allows injection of IHttpContextAccessor 
    /// </summary>
    public class ContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IHttpContextAccessor HttpContextAccessor
        {
            get { return _httpContextAccessor; }
        }

        public ContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

    }
}
