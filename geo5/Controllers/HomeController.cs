using static DataLibrary.Logic.UserProcessor;
using geo5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace geo5.Controllers
{
    public class HomeController : Controller
    {
        public static user currentUser = new user();
        public static place currentPlace = new place(0, 0, "");
        public static place submittedPlace = new place(0, 0 ,"");
        public static result currentGame = new result();
        public static int currentRound;
    
        public ActionResult GlobalLeaderboard()
        {
            List<DataLibrary.Models.user> temp = getUsersStats();
            List<user> userList = new List<user>();
            userList = temp.ConvertAll(new Converter<DataLibrary.Models.user, user>(data.GetUserData));

            return View(userList);
        }

        public ActionResult FriendsLeaderboard()
        {
            List<DataLibrary.Models.user> temp = getUsersStats();
            List<user> userList = new List<user>();
            userList = temp.ConvertAll(new Converter<DataLibrary.Models.user, user>(data.GetUserData));

            return View(userList);
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ShowResults()
        {
            currentGame.correctlat = currentPlace.lat;
            currentGame.correctlng = currentPlace.lng;
            currentGame.submittedlat = submittedPlace.lat;
            currentGame.submittedlng = submittedPlace.lng;
            currentGame.currentround = currentRound;

            currentGame.currentdistance = distance(currentGame.correctlat, currentGame.correctlng, currentGame.submittedlat, currentGame.submittedlng, 'K');
            if(currentGame.currentdistance < 1) {
                currentGame.numCorrect++;
            }

            double tempPoints = 0;
            tempPoints = currentGame.currentdistance;
            tempPoints = Math.Ceiling(tempPoints);
 
            if(tempPoints > 2000)
            {
                tempPoints = 0;
            }
            tempPoints = 2000 - tempPoints;
            
            currentGame.points = Convert.ToInt32(tempPoints);
            currentGame.percent = (tempPoints / 2000)*100;

            if (currentRound == 1) {
                currentGame.points1 = tempPoints;
                currentGame.distance1 = currentGame.currentdistance;
            }
            else if(currentRound == 2) {
                currentGame.points2 = tempPoints;
                currentGame.distance2 = currentGame.currentdistance;                
                currentGame.avgdistance = (currentGame.distance1 + currentGame.distance2 + currentGame.distance3) / 2;
            }
            else if (currentRound == 3) {
                currentGame.points3 = tempPoints;
                currentGame.distance3 = currentGame.currentdistance;                
                currentGame.avgdistance = (currentGame.distance1 + currentGame.distance2 + currentGame.distance3) / 3;
            }
            else if (currentRound == 4) {
                currentGame.points4 = tempPoints;
                currentGame.distance4 = currentGame.currentdistance;
                currentGame.avgdistance = (currentGame.distance1 + currentGame.distance2 + currentGame.distance3 + currentGame.distance4) / 4;
            }
            else if (currentRound == 5) {
                currentGame.points5 = tempPoints;
                currentGame.distance5 = currentGame.currentdistance;
                currentGame.avgdistance = (currentGame.distance1 + currentGame.distance2 + currentGame.distance3 + currentGame.distance4 + currentGame.distance5) / 5;
            }
         
            return View(currentGame);
        }

        public ActionResult GameFinish()
        {
            currentGame.points = Convert.ToInt32(currentGame.points1 + currentGame.points2 + currentGame.points3 + currentGame.points4 + currentGame.points5);
            return View(currentGame);
        }

        //stats save
        public ActionResult BackToMain()
        {
            if (currentGame.numCorrect != 0)
            {
                int temp = Convert.ToInt32(currentUser.numCorrect);
                temp = temp + (Convert.ToInt32(currentGame.numCorrect));

                SetNewCorrect(currentUser.userId, temp);
            }

            if (currentGame.gametype == "global")
            {
                if(currentUser.bgGlobal < currentGame.points)
                {
                    SetbgGlobal(currentUser.userId, currentGame.points);
                }
                return RedirectToAction("World", "Home");
            }
            else if (currentGame.gametype == "us")
            {
                if (currentUser.bgWorld < currentGame.points)//need to change world to us in database im dumb
                {
                    SetbgWorld(currentUser.userId, currentGame.points);
                }
                return RedirectToAction("US", "Home");
            }
            else if(currentGame.gametype == "famous")
            {
                if (currentUser.bgFamous < currentGame.points)
                {
                    SetbgWorld(currentUser.userId, currentGame.points);
                }
                return RedirectToAction("Famous", "Home");
            }
            
            return RedirectToAction("World", "Home");
        }

        //WORLD//
        public ActionResult World()
        {
            return View();
        }

        public ActionResult WorldGuess()
        {
            place temp = new place(0, 0, "");
            temp = GetFamousPlace(temp);
            temp.currentRound = currentRound;
            temp.currentGameType = currentGame.gametype;

            return View(temp);
        }

        public ActionResult WorldGetGame()
        {
            currentGame = new result();
            currentGame.numCorrect = 0;
            currentRound = 1;           
            currentGame.gametype = "global";
            return RedirectToAction("WorldGuess", "Home");
        }

        public ActionResult WorldGetNextRound()
        {
            if(currentRound == 5)
            {
                return RedirectToAction("GameFinish", "Home");
            }
            currentRound++;
            return RedirectToAction("WorldGuess", "Home");
        }

        public ActionResult PostSubmissionGlobal(double slat, double slng, double clat, double clng)
        {
            if (ModelState.IsValid)
            {
                place temp = new place(0, 0, "");
                temp.lat = slat;
                temp.lng = slng;
                submittedPlace = temp;
                currentPlace.lat = clat;
                currentPlace.lng = clng;
            }
            return RedirectToAction("ShowResults", "Home");
        }

        //US//
        public ActionResult US()
        {
            return View();
        }

        public ActionResult USGuess()
        {
            place temp = new place(0, 0, "");
            temp = GetFamousPlace(temp);
            temp.currentRound = currentRound;
            temp.currentGameType = currentGame.gametype;

            return View(temp);
        }

        public ActionResult USGetGame()
        {
            currentGame = new result();
            currentGame.numCorrect = 0;
            currentRound = 1;            
            currentGame.gametype = "us";
            return RedirectToAction("USGuess", "Home");
        }

        public ActionResult USGetNextRound()
        {
            if (currentRound == 5)
            {
                return RedirectToAction("GameFinish", "Home");
            }
            currentRound++;
            return RedirectToAction("USGuess", "Home");
        }

        public ActionResult PostSubmissionUS(double slat, double slng, double clat, double clng)
        {
            if (ModelState.IsValid)
            {
                place temp = new place(0, 0, "");
                temp.lat = slat;
                temp.lng = slng;
                submittedPlace = temp;
                currentPlace.lat = clat;
                currentPlace.lng = clng;
            }
            return RedirectToAction("ShowResults", "Home");
        }

        //FAMOUS//
        public ActionResult Famous()
        {
            return View();
        }

        public ActionResult FamousGuess()
        {
            place temp = new place(0, 0, "");
            temp = GetFamousPlace(temp);
            temp.currentRound = currentRound;
            temp.currentGameType = currentGame.gametype;
            currentPlace = temp;

            return View(temp);
        }

        public ActionResult FamousGetGame()
        {
            currentGame = new result();
            currentGame.numCorrect = 0;
            currentRound = 1;
            currentGame.gametype = "famous";
            return RedirectToAction("FamousGuess", "Home");
        }

        public ActionResult FamousGetNextRound()
        {
            if (currentRound == 5)
            {
                return RedirectToAction("GameFinish", "Home");
            }
            currentRound++;
            return RedirectToAction("FamousGuess", "Home");
        }

        public ActionResult PostSubmissionFamous(double subLat, double subLng)
        {
            if (ModelState.IsValid)
            {
                place temp = new place(0, 0, "");
                temp.lat = subLat;
                temp.lng = subLng;
                submittedPlace = temp;
            }
            return RedirectToAction("ShowResults", "Home");
        }

        //ACCOUNT
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ChangeEmail(userSettings model)
        {
            UpdateEmail(currentUser.userId, model.email);
            return RedirectToAction("Settings", "Home");
        }

        public ActionResult ChangePassword(userSettings model)
        {
            UpdatePassword(currentUser.userId, model.password);
            return RedirectToAction("Settings", "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(userRegister model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreateUser(model.username, model.password, model.email);
                    //currentUser = user;//sets login
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("email", "There is already a user with this email. Please use a different email.");
                    return View(model);
                }
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(user model)
        {
            List<DataLibrary.Models.user> temp = LoadUser(model.username, model.password);

            if (temp.Count > 0)
            {
                List<user> userList = new List<user>();

                userList = temp.ConvertAll(new Converter<DataLibrary.Models.user, user>(data.GetUserData));
                user user = userList[0];

                Session["Id"] = user.userId;
                currentUser = user;//sets login            
                //return this.View(new HomeViewModel { Name = user.username });
                //return RedirectToAction()
                return RedirectToAction("World", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

        //MATH
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                dist = Math.Round(dist, 2);
                return (dist);
            }
        }

        //temp method for testing
        public Models.place GetFamousPlace(place temp)
        {
            List<place> places = new List<place>();
            places.Add(new place(60.171001, 24.939350, "Finland"));
            places.Add(new place(51.510020, -0.134730, "Great Britain"));
            places.Add(new place(41.8902, 12.4922, "Italy"));
            places.Add(new place(25.195302, 55.272879, "United Arab Emirates"));
            places.Add(new place(1.283404, 103.863134, "Singapore"));
            places.Add(new place(29.976768, 31.135538, "Egypt"));
            places.Add(new place(40.757876, -73.985592, "United States"));
            places.Add(new place(34.1345088, -118.3218415, "United States"));
            places.Add(new place(40.4331163, 116.5641774, "United States"));
            var random = new Random();
            temp = places[random.Next(places.Count)];
            currentPlace = temp;

            return temp;
        }
    }
}