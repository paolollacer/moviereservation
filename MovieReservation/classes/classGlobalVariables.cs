using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservation.classes
{
    public static class classGlobalVariables
    {
        public static string Server { get; set; } = "";
        public static string Sqlport { get; set; } = "";
        public static string Username { get; set; } = "";
        public static string Password { get; set; } = "";
        public static string Database { get; set; } = "";
        public static bool MSSQLMode { get; set; } = false;
    }
}
