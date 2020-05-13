using System;
using System.Collections.Generic;

namespace vue_webApi.Entities
{
    public partial class CommentsPraise
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CommentId { get; set; }
        public int? Status { get; set; }
    }
}
