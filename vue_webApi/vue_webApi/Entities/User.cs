using System;
using System.Collections.Generic;

namespace vue_webApi.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string CreateTime { get; set; }
        public string Phone { get; set; }
        public int? Integral { get; set; }
    }
}
