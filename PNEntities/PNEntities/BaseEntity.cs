using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PNEntities
{
    public class BaseEntity
    {
        [Required]
        [JsonProperty(PropertyName = "id")] 
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "dateCreated")]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Required]
        [JsonProperty(PropertyName = "dateLastModified")]
        [Display(Name = "Date Last Modified")]
        public DateTime DateLastModified { get; set; }

        public BaseEntity()
        {
        }
    }
}
