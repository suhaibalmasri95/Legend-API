using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Photo
    {
        [JsonProperty(PropertyName = "File")]
        public IFormFile File { get; set; }
    }
}
