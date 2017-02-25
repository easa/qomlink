using System;
using qomlink.Models;
using Entities;

namespace qomlink
{
	 class Program
	 {
		  static void Main(string[] args)
		  {
				int counter;
				bool doExit;
				ConsoleKey key;
				counter = 0;
				doExit = false;

				welcomepage();
				while (!doExit)
				{
					 key = Console.ReadKey().Key;
					 //console.log("key resived - " + key);
					 //console.upline();
					 switch (key)
					 {
						  case ConsoleKey.Enter:
								login();
								break;
						  case ConsoleKey.Backspace:
								logout();
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
								help();
								break;
						  case ConsoleKey.S:
								Shedule();
								break;
						  case ConsoleKey.R:
								register();
								break;
						  case ConsoleKey.N:
								wifi();
								break;
						  default:
								console.log("What do you wanna do? Press F1 for help;");
								break;
					 }
					 if (!(key == ConsoleKey.Escape))
						  counter = 0;
				}
		  }

		  static public async void login()
		  {
				Service.Service sv = new Service.Service("");
				var bl = await sv.login();
				console.log((bl) ? "loged in seccessfuly connected!" : sv.message + "press R to register!");
				
				#region last code
				//switch (config.login())
				//{
				//	 case status.connect:
				//		  console.log("Connected!");
				//		  break;
				//	 case status.disconnect:
				//		  console.log("Unable to connect! Maybe wrong pass, please register again:");
				//		  register();
				//		  break;
				//	 case status.notregistered:
				//		  register();
				//		  break;
				//	 case status.badGetway:
				//		  console.log("No wifi network found!");
				//		  break;
				//	 default:
				//		  console.log("Unavailable!");
				//		  break;
				//}
				#endregion
		  }
		  static public void welcomepage()
		  {
				Console.WriteLine("Hello, welcome to qomlink 0.3");
				Console.WriteLine("Press F1          to help.");
				//help();
		  }
		  static public async void logout()
		  {
				Service.Scheduling.remove();
				Service.Service sv = new Service.Service("");
				var bl = await sv.logout();
				console.log((bl) ? "loged out seccessfuly!" : sv.message);
		  }
		  static public void help()
		  {
				Console.WriteLine("Press ENTER       to login.");
				Console.WriteLine("Press ESCAP       to EXIT.");
				Console.WriteLine("Press BACKSPACE   to logout.");
				Console.WriteLine("Press S           to sheduling automatic logins.");
				Console.WriteLine("Press R           to register user and pass.");
				Console.WriteLine("Press C           to clean screen.");
				Console.WriteLine("Press N           to connect to wifi.");
				Console.WriteLine("\nDeveloped by @eisanodehi");
		  }
		  static public async void register()
		  {
				console.log("Register - Enter Username: ");
				string username = Console.ReadLine();
				console.log("\nEnter Password: ");
				string password = Console.ReadLine();
				if (username.Length < 5 || password.Length < 3)
					 console.log("Invalid!");
				var temp_user = new User(username, password);
				Service.Service sv = new Service.Service("");
				sv.addUser(temp_user);
				var temp = await sv.login();
				console.log(temp.ToString());
		  }
		  static public void Shedule()
		  {
				console.log("This will login automaticly, and will remove by pressing BACKSPACE.\n");
				Console.Write("Please Enter the minutes to try login: ");
				string tempmin = Console.ReadLine();
				int min = 1;
				int.TryParse(tempmin, out min);
				Service.Scheduling.set(min);
		  }
		  static public void wifi()
		  {
				console.log("wifi\n");
				//bool isenabled = new Batch().Set(Commands.EnableWiFi).Exec();
				console.log((false) ? "connected" : "notConnected");
		  }

	 }
}