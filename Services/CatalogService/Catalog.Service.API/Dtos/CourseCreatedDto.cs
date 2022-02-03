﻿namespace Catalog.Service.API.Dtos
{
    public class CourseCreatedDto
    {
       
        public string name { get; set; }
        public string description { get; set; }

        public decimal price { get; set; }

        public string picture { get; set; }

        public string userId { get; set; }

        public FeatureDto feature { get; set; }

        public string categoryId { get; set; }


    }
}
