using System.ComponentModel;
using System.Threading;

namespace userCall.Models
{
    static class Sheduling
    {
        static bool condition;
        static int minutes;

        public static void set(int min)
        {
            if (!(0 < min && min < 1000))
            {
                console.log("Inaproprate!");
                return;
            }
            minutes = min;
            condition = true;

            console.log("Sheduling sets every " + minutes + " minutes!");
            main();
        }
        public static void remove()
        {
            if(condition)
                console.log("Sheduling removed!");

            condition = false;
        }
        static void main()
        {
            myFunc();
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                Thread.Sleep(minutes * 60000);
            });
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {
                console.log(" " + minutes + " m past. ");
                if (condition)
                    main();
            });
            bw.RunWorkerAsync();
        }
        static void myFunc()
        {
            iface.login();
        }
    }
}
