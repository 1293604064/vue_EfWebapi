using System;
using System.Collections.Generic;

namespace vue_webApi.Entities
{
    public partial class Questions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int? Praise { get; set; }
        public int? TagsId { get; set; }
        public string Created { get; set; }
        public int? Comment { get; set; }
        public int? UserId { get; set; }
    }
}
