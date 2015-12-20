using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggV1.Controllers
{
    public static class Checking
    {
        private static bool isAuthorized = false;
        private static bool isLoggedin = false;
        private static int userId = -1;



        public static bool IsAuthorized()
        {
            return isAuthorized;
        }

        public static void IsAuthorized(bool value)
        {
            isAuthorized = value;
        }

        public static bool IsLoggedin()
        {
            return isLoggedin;
        }

        public static void IsLoggedin(bool value)
        {
            isLoggedin = value;
        }

        public static int UserId()
        {
            return userId;
        }

        public static void UserId(int id)
        {
            userId = id;
        }

    }
}