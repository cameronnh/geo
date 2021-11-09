using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geo5.Models
{
    public class user
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int bgGlobal { get; set; }
        public int bgWorld { get; set; }
        public int bgFamous { get; set; }
        public int numCorrect { get; set; }
    }
}