using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geo5.Models
{
    public class result
    {
        public double correctlat { get; set; }
        public double correctlng { get; set; }
        public double submittedlat { get; set; }
        public double submittedlng { get; set; }

        public double currentdistance { get; set; }
        public double distance1 { get; set; }
        public double distance2 { get; set; }
        public double distance3 { get; set; }
        public double distance4 { get; set; }
        public double distance5 { get; set; }
        public double avgdistance { get; set; }

        public double currentround { get; set; }
        public string gametype { get; set; }
        public double percent { get; set; }
        public double numCorrect { get; set; }

        public int points { get; set; }
        public double points1 { get; set; }
        public double points2 { get; set; }
        public double points3 { get; set; }
        public double points4 { get; set; }
        public double points5 { get; set; }
    }
}