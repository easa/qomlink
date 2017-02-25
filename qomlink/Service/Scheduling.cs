using System;
using System.ComponentModel;
using System.Threading;

namespace Service
{
    public static class Scheduling
    {
        static bool condition;
        static int minutes;

        public static void set(Func<string, string> task, int min)
        {
            if (!(0 < min && min < 1000))
            {
                return;
            }
            minutes = min;
            condition = true;
            main(task);
				message = "setting Schedule done successfuly!";
        }
        public static void remove()
        {
            condition = false;
				message = "removing Schedule done seccussfuly!";
        }
		  /// <summary>
		  /// It's the main scheduling base of every thing, base of tasks
		  /// , I use it to sleep!
		  /// </summary>
        static void main(Func<string, string> myTask)
        {
            task(myTask);
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
                    main(myTask);
					 });
            bw.RunWorkerAsync();
        }
		  /// <summary>
		  /// what should happen after time pass is in here
		  /// </summary>
		  static async void task(Func<string, string> mytask)
		  {
				mytask(minutes + " min pass");
				Service sv = new Service();
				var temp = await sv.login();
				mytask("login " + (temp ? "succssfuly" : sv.message));
		  }
		  public static string message { get; set; }
	 }
}
