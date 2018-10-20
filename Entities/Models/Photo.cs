using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Photo
    {
        public IFormFile File { get; set; }
    }
}
