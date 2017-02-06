using System;
using userCall.Models.Enums;

namespace userCall.Models
{
    class User
    {
        static public status login(string username, string password)
        {
            string url = "/login";
            string data = string.Format("username={0}&password={1}", username, password);
            if (check() != status.exist)
                return check();
            string response = Network.connect(url, data);
            if (response.IndexOf("<title>mikrotik hotspot > redirect</title>") >= 0)
                return status.connect;
            else if (response.IndexOf("<title>LoginHotspot</title>") > 0)
                return status.disconnect;
            else if (response.IndexOf("The remote server returned an error: (502) Bad Gateway") >= 0)
                return status.badGetway;
            else return status.alreadyLogin;
        }
        static public status login()
        {
            read();
            return login(username, password);
        }
        static public status logout()
        {
            string url = "/logout";

            string response = Network.connect(url, "");

            var result = response.IndexOf("<title>mikrotik hotspot > logout</title>");
            if (result >= 0)
                return status.disconnect;
            else if (response.IndexOf("The remote server returned an error: (502) Bad Gateway") >= 0)
                return status.badGetway;
            else
                return status.alreadyLogout;
        }
        static public status register(string paramusername , string parampassword)
        {
            save(string.Format("{0}&{1}$", paramusername, parampassword));
            read();
            return login(username, password);
        }
        static string username { get; set; }
        static string password { get; set; }
        static status check()
        {
            read();
            if (username == null || password == null)
                return status.notregistered;
            if (username.Length < 3 || password.Length < 3)
                return status.notregistered;
            else
                return status.exist;
        }
        static status read()
        {
            var a1 = DB.readfile();
            if (a1 == null) return status.notexist;
            var a2 = a1.Split('$');
            var a3 = a2[0].Split('&');
            username = a3[0];
            password = a3[1];
            return status.exist;
        }
        static bool save(string data)
        {
            return DB.savefile(data);
        }
    }
}
