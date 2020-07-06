using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PNEntities;

namespace PNBlazorApp.Server.Containers
{
    
    /// <summary>
    /// Wrapper class for PrayerGroup entities required? by GraphQL.Client
    /// </summary>
    public class PrayerGroupContainer
    {
        public List<PrayerGroup> PrayerGroups { get; set; }

        public PrayerGroup createPrayerGroup { get; set; }

        public PrayerGroup updatePrayerGroup { get; set; }
    }
}
