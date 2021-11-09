using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace geo5.Models
{
    public class data
    {
        public static user GetUserData(DataLibrary.Models.user temp)
        {
            
            return new user
            {
                userId = temp.userID,   
                username = temp.username,
                email = temp.email,
                bgGlobal = temp.bgGlobal,
                bgWorld = temp.bgWorld,
                bgFamous = temp.bgFamous,
                numCorrect = temp.numCorrect
            };            
        }
    }
}