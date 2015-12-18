using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggV1.Controllers
{
    public static class Checking
    {
        private static bool isAuthorized = false;

        public static bool IsAuthorized()
        {
            return isAuthorized;
        }

        public static void IsAuthorized(bool value)
        {
            isAuthorized = value;
        }

    }
}