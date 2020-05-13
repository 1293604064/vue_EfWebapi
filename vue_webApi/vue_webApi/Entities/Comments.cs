using System;
using System.Collections.Generic;

namespace vue_webApi.Entities
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int? UserId { get; set; }
        public int? Praise { get; set; }
        public int? QuestionId { get; set; }
        public int? Caicai { get; set; }
    }
}
