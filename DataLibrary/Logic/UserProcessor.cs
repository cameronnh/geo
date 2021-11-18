﻿using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public class UserProcessor
    {
        public static int CreateUser(string username, string password, string email)
        {
            user data = new user
            {
                username = username,
                password = password,
                email = email
            };
            string sql = @"INSERT into dbo.[user] (username, password, email) values(@username, @password, @email)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<user> LoadUser(string username, string password)
        {
            string sql = @"SELECT userID, username, email, bgGlobal, bgWorld, bgFamous, numCorrect FROM dbo.[user] WHERE username = '" + username + " ' AND password = '" + password + "';";

            return SqlDataAccess.LoadData<user>(sql);
        }

        public static int SetbgGlobal(int userID, int newVal)
        {
            user data = new user
            {
                userID = userID,
                bgGlobal = newVal
            };
            string sql = @"UPDATE dbo.[user] SET bgGlobal = '" + newVal + "' WHERE userID = '" + userID + "';";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int SetbgWorld(int userID, int newVal)
        {
            user data = new user
            {
                userID = userID,
                bgWorld = newVal
            };
            string sql = @"UPDATE dbo.[user] SET bgWorld = '" + newVal + "' WHERE userID = '" + userID + "';";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int SetbgFamous(int userID, int newVal)
        {
            user data = new user
            {
                userID = userID,
                bgFamous = newVal
            };
            string sql = @"UPDATE dbo.[user] SET bgFamous = '" + newVal + "' WHERE userID = '" + userID + "';";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int SetNewCorrect(int userID, int newVal)
        {
            user data = new user
            {
                userID = userID,
                numCorrect = newVal
            };
            string sql = @"UPDATE dbo.[user] SET numCorrect = '" + newVal + "' WHERE userID = '" + userID + "';";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<user> getUsersStats()
        {
            string sql = @"SELECT username, bgGlobal, bgWorld, bgFamous, numCorrect FROM dbo.[user];";
            List<user> temp = SqlDataAccess.LoadData<user>(sql);
            
            return temp;
        }

        public static int ChangeEmail(int userID, string email)
        {
            user data = new user
            {
                userID = userID,
                email = email           
            };

            string sql = @"UPDATE dbo.[user] SET email = '" + email + "' WHERE userID = '" + userID + "';";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int ChangePassword(int userID, string password)
        {
            user data = new user
            {
                userID = userID,
                password = password
            };

            string sql = @"UPDATE dbo.[user] SET password = '" + password + "' WHERE userID = '" + userID + "';";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}