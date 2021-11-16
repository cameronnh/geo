using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geo5.Models
{
    public class place
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string country { get; set; }
        public place(double ilat, double ilng, string icoun)
        {
            lat = ilat;
            lng = ilng;
            country = icoun;
        }
        public int currentRound { get; set; }
        public string currentGameType { get; set; }
    }
}