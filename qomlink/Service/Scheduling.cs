using System.ComponentModel;
using System.Threading;

namespace Service
{
    public static class Scheduling
    {
        static bool condition;
        static int minutes;

        public static void set(int min)
        {
            if (!(0 < min && min < 1000))
            {
                return;
            }
            minutes = min;
            condition = true;
            main();
        }
        public static void remove()
        {
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
                if (condition)
                    main();
            });
            bw.RunWorkerAsync();
        }
        static void myFunc()
        {
            //TODO login
        }
    }
}
