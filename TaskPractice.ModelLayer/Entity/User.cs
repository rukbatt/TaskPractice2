using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPractice.ModelLayer.Entity
{
    public class User
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string authToken { get; set; }
    }
}
