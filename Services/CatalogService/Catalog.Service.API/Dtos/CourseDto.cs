using System;

namespace Catalog.Service.API.Dtos
{
    public class CourseDto
    {
      
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public decimal price { get; set; }

        public string userId { get; set; }
        public string picture { get; set; }

        
        public DateTime createdTime { get; set; }

        public FeatureDto feature { get; set; }

       
        public string categoryId { get; set; }

     
        public CategoryDto category { get; set; }
    }
}
