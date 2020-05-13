using System;
using System.Collections.Generic;

namespace vue_webApi.Entities
{
    public partial class QuestionPraise
    {
        public int Id { get; set; }
        public int? QuestionsId { get; set; }
        public int? UserId { get; set; }
    }
}
