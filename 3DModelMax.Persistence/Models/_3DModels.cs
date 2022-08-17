
﻿using Microsoft.AspNetCore.Http;

﻿using Microsoft.EntityFrameworkCore;


namespace _3DModelMax.Host.Models
{
    public class _3DModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; } 
        public Authors Author { get; set; } 
        public IFormFile file { get; set; }
    }
}
