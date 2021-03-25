using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Hangman
{
    public static class Database
    {
        public static SQLiteConnection Con;
        public static string dbPath;
        public static string dbName;

        static Database()
        {
            dbName = "hangmanDB.sqlite";
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);// Documents folder
            if (dbPath != null)
            {
                Con = new SQLiteConnection(dbPath);
            }
        }

        public static List<Users> LoadUsers()
        {
            Con.CreateTable<Users>();

            if (Con.Table<Users>().Count() == 0)
            {
                // Insert FakeData if Table is empty
                List<Users> tempData = GenerateFakeUserData();

                foreach (Users user in tempData)
                {
                    Con.Insert(user);
                }
            }

            return Con.Table<Users>().ToList();
        }

        public static List<Users> LoadActiveUser()
        {
            Con.CreateTable<Users>();

            return Con.Query<Users>("SELECT * FROM Users WHERE active = 'true'").ToList();
        }




        public static void AddItem(string username, int wins, int loses)
        {
            try
            {
                var insertData = new tblLeaderboard() { Username = username, Wins = wins, Loses = loses };
                Con.Insert(insertData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        public static void CreateProfile(string username)
        {
            try
            {
                var insertData = new Users() { username = username, active = "true", wins = 0, loses = 0, coins = 0, xp = 0 };
                Con.Insert(insertData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        public static void UpdateUser(List<Users> activeUser)
        {
            try
            {
                var editData = new Users() { username = activeUser[0].username, active = "true", wins = activeUser[0].wins, loses = activeUser[0].loses, xp = activeUser[0].xp, coins = activeUser[0].coins, id = activeUser[0].id };

                Con.Update(editData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Error:" + e.Message);
            }
        }


        public static List<tblProfile> LoadUserProfile()
        {
            // Create Database if it doesn't already exist
            Con.CreateTable<tblProfile>();

            return Con.Table<tblProfile>().ToList();
        }

        private static List<Users> GenerateFakeUserData()
        {
            string[] firstNames = { "Liam", "Noah", "Oliver", "William", "Elijah", "James", "Benjamin", "Lucas", "Mason", "Ethan" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };

            Users[] myUsers = new Users[10];

            Random myRandom = new Random();

            for (int i = 0; i < 10; i++)
            {
                Users tempUser = new Users();
                tempUser.username = $@"{firstNames[myRandom.Next(0, firstNames.Length)]} {lastNames[myRandom.Next(0, lastNames.Length)]}";
                tempUser.active = $@"false";
                tempUser.wins = myRandom.Next(0, 250);
                tempUser.loses = myRandom.Next(0, 50);
                tempUser.coins = (myRandom.Next(0, 50) * 5);
                tempUser.xp = myRandom.Next(0, 500);

                myUsers[i] = tempUser;
            }

            return myUsers.ToList();
        }
    }
}