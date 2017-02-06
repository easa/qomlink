using System;
using System.ComponentModel;
using System.Threading;
using userCall.Models;
using userCall.Models.Enums;

//using NativeWifi;

namespace userCall
{
    class Program
    {
        static void Main(string[] args)
        {
            iface.run();
        }
    }
    static class iface
    {
        public static void run()
        {
            int counter;
            bool doExit; ConsoleKey key;
            counter = 0;
            doExit = false;
            iface.welcomepage();
            while (!doExit)
            {
                key = Console.ReadKey().Key;
                console.log("key resived - " + key);
                console.upline();
                switch (key)
                {
                    case ConsoleKey.Enter:
                        iface.login();
                        break;
                    case ConsoleKey.Backspace:
                        iface.logout();
                        break;
                    case ConsoleKey.Escape:
                        if (++counter > 1)
                            doExit = true;
                        else
                            console.log("Press \"Escape\" again to exit!\n");
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        break;
                    case ConsoleKey.F1:
                        iface.help();
                        break;
                    case ConsoleKey.S:
                        iface.Shedule();
                        break;
                    case ConsoleKey.R:
                        iface.register();
                        break;

                    default:
                        console.log("What do you wanna do? Press F1 for help;");
                        break;
                }
                if (!(key == ConsoleKey.Escape))
                    counter = 0;
            }
        }
        static public void login()
        {
            switch (User.login())
            {
                case status.connect:
                    console.log("Connected!");
                    break;
                case status.disconnect:
                    console.log("Unable to connect! Maybe wrong pass, please register again:");
                    iface.register();
                    break;
                case status.notregistered:
                    iface.register();
                    break;
                case status.badGetway:
                    console.log("No wifi network found!");
                    break;
                default:
                    console.log("Unavailable!");
                    break;
            }
        }
        static public void welcomepage()
        {
            Console.WriteLine("Hello, welcome to UserCall 0.2 . ");
            Console.WriteLine("Press F1          to help.");
            iface.help();
        }
        static public void logout()
        {
            Sheduling.remove();
            switch (User.logout())
            {
                case status.disconnect:
                    console.log("Disconnected!");
                    break;
                case status.badGetway:
                    console.log("No wifi network found!");
                    break;
                default:
                    console.log("Allready disconnected!");
                    break;
            }
        }
        static public void help()
        {
            Console.WriteLine("Press ENTER       to login.");
            Console.WriteLine("Press ESCAP       to EXIT.");
            Console.WriteLine("Press BACKSPACE   to logout.");
            Console.WriteLine("Press S           to sheduling automatic logins.");
            Console.WriteLine("Press R           to register user and pass.");
            Console.WriteLine("Press c           to clean screen.");
            Console.WriteLine("\nDeveloped by @eisanodehi");
        }
        static public void register()
        {
            console.log("Register - Enter Username: ");
            string username = Console.ReadLine();
            console.log("\nEnter Password: ");
            string password = Console.ReadLine();
            if (username.Length < 5 || password.Length < 3)
                console.log("Invalid!");
            var temp = User.register(username, password);
            if (temp == status.connect || temp == status.alreadyLogin)
                console.log("Done!");
        }
        static public void Shedule()
        {
            console.log("This will login automaticly, and will remove by pressing BACKSPACE.\n");
            Console.Write("Please Enter the minutes to try login: ");
            string tempmin = Console.ReadLine();
            int min = 1;
            int.TryParse(tempmin, out min);
            Sheduling.set(min);
        }
    }

   
    static class tempsheduling
    {
        //static BackgroundWorker bw { get; set; }
        //static int sheduledTime { get; set; }

        //public static void remove()
        //{
        //    bw.Dispose();
        //}
        //public static void setting(int time)
        //{
        //    bw = new BackgroundWorker();
        //    bw.DoWork += new DoWorkEventHandler(
        //    delegate (object o, DoWorkEventArgs args)
        //    {
        //        console.log("Please wait..");
        //        var myThread = new Thread(new ThreadStart(thlogin));
        //        myThread.Start();

        //    });
        //    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
        //   delegate (object o, RunWorkerCompletedEventArgs args)
        //   {
        //       console.log("Finished");
        //   });

        //    bw.RunWorkerAsync();
        //}
        //static void thlogin()
        //{
        //    switch (User.login())
        //    {
        //        case status.connect:
        //            //console.log("Connected..");
        //            break;
        //        case status.disconnect:
        //            console.log("disconnect");
        //            break;
        //        case status.notregistered:
        //            console.log("notregistered");
        //            break;
        //        case status.badGetway:
        //            console.log("Unavailable!");
        //            break;
        //        default:
        //            console.log("Unavailable!");
        //            break;
        //    }
        //}
        //public static void set()
        //{
        //    console.log("please wait..");
        //    bw = new BackgroundWorker();

        //    bw.DoWork += new DoWorkEventHandler(
        //    delegate (object o, DoWorkEventArgs args)
        //    {

        //    });

        //    // what to do when progress changed (update the progress bar for example)
        //    bw.ProgressChanged += new ProgressChangedEventHandler(
        //    delegate (object o, ProgressChangedEventArgs args)
        //    {
        //        var Text = string.Format("{0}% Completed", args.ProgressPercentage);
        //        console.log(Text);
        //    });

        //    // what to do when worker completes its task (notify the user)
        //    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
        //    delegate (object o, RunWorkerCompletedEventArgs args)
        //    {
        //        var Text = "Finished!";
        //        console.log(Text);
        //    });

        //    bw.RunWorkerAsync();
        //}
    }
}
//namespace Coding
//{
//    public static class MyExtensions
//    {
//        public static string EnCode(this string str)
//        {
//            var sd = str.Split(new char[] { ' ', '.', '?' },
//                             StringSplitOptions.RemoveEmptyEntries).Length;
//            StringBuilder sb = new StringBuilder();
//            int lenstr = str.Length;
//            char chstr;
//            Random rnd = new Random();
//            int rndnum;
//            for (var i = 0; i < lenstr; i++)
//            {
//                rndnum = rnd.Next(0, 9);
//                for (var j = 0; j < rndnum; j++)
//                {
//                    rndnum = rnd.Next(0, 9);
//                    sb.Append(rndnum);
//                }
//                chstr = str[i];
//                sb.Append(chstr);
//            }
//            return sb.ToString();
//        }
//        public static string DeCode(this string str)
//        {
//            StringBuilder sb = new StringBuilder();
//            int lenstr = str.Length;
//            char chstr, ch1;
//            int intch;
//            for (var i = 0; i < lenstr; i++)
//            {
//                chstr = str[i];
//                intch = Convert.ToInt32(chstr.ToString());
//                for (var j = 0; j > 9; j++)
//                {
//                    ch1 = str[i + j];
//                    if (Convert.ToInt32(ch1.ToString()) < intch)
//                        break;
//                }
//                chstr = str[--i - 1];
//                sb.Append(intch);
//            }
//            return sb.ToString();
//        }
//    }
//}