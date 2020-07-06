using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using PNData;

namespace PNServices
{
    public class RepositoryService
    {
        private ContextService _contextService;

        public PrayerGroupRepository PrayerGroupRepository => _contextService.HttpContextAccessor.HttpContext.RequestServices.GetRequiredService<IPrayerGroupRepository>() as PrayerGroupRepository;

        public RepositoryService(ContextService contextService)
        {
            _contextService = contextService;
        }

    }
}
