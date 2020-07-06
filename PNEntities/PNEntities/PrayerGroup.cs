using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace PNEntities
{
    public class PrayerGroup : BaseEntity
    {
        [Required]
        [JsonProperty(PropertyName = "prayergroupname")]
        [Display(Name = "Prayer Group Name")]
        public string PrayerGroupName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "prayergroupdescription")]
        [Display(Name = "Prayer Group Description")]
        public string PrayerGroupDescription { get; set; }


        // TODO:  Implement
        //public List<Believer> Believers { get; set; } = new List<Believer>();

        public PrayerGroup() : base()
        {
        }
    }
}
