using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace PNEntities
{
    public class Believer : BaseEntity
    {
        [Required]
        [JsonProperty(PropertyName = "userName")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Believer() : base()
        {
        }

    }
}
