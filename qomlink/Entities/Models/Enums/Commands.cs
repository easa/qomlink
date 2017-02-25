using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Enums
{
	 static public class Commands
	 {
		  /// <summary>
		  /// need to set a name useing string format like this=>(connectToNetwork, name)
		  /// </summary>
		  static public string ConnectToWiFi { get { return "netsh wlan connect name={0}"; } }
		  static public string EnableWiFi { get { return "netsh interface set interface \"Wi-Fi\" Enable"; } }
		  static public string EnableWNC { get { return "netsh interface set interface \"Wireless Network Connection\" Enable"; } }
	 }
}
