using System;
using System.Text;
using System.IO;
using System.Net;
using Entities;
using System.Threading.Tasks;

namespace Service
{
	 class Network
	 {
		  async public Task<bool> connectToWifi()
		  {
				return false;
				//return await new Batch().Set(string.Format(Commands.ConnectToWiFi, "Qom-Link")).Exec();
		  }
		  public async Task<status> connect(User user)
		  {
				if (user == null) return status.Not_authorized;
				string website = string.Format("{0}/{1}", Url, "login");
				string data = string.Format("username={0}&password={1}", user.username, user.password);
				string response = await sendRequest(website, data);
				if (response.IndexOf("<title>mikrotik hotspot > redirect</title>") >= 0)
					 return status.Connected;
				else if (response.IndexOf("<title>LoginHotspot</title>") > 0)
					 return status.Disconnected;
				else if (response.IndexOf("The remote server returned an error: (502) Bad Gateway") >= 0)
					 return status.Bad_getway;
				else if (response.IndexOf("Configuration system failed to initialize") >= 0)
					 return status.Error;
				else return status.Already_connected; 
		  }
		  async public Task<status> disConnect()
		  {
				string website = string.Format("{0}/{1}", Url, "logout");
				string response = await sendRequest(website, null);
				if (response.IndexOf("<title>mikrotik hotspot > logout</title>") >= 0)
					 return status.Disconnected;
				else if (response.IndexOf("The remote server returned an error: (502) Bad Gateway") >= 0)
					 return status.Bad_getway;
				else
					 return status.Already_disconnected;
		  }

		  async Task<string> sendRequest(string url, string postdata)
		  {
				try
				{
					 WebRequest request = WebRequest.Create(url);
					 string postData = postdata;
					 request.Method = "POST";
					 byte[] byteArray = Encoding.UTF8.GetBytes(postData);
					 request.ContentType = "application/x-www-form-urlencoded";
					 request.ContentLength = byteArray.Length;
					 Stream dataStream = await request.GetRequestStreamAsync();
					 dataStream.Write(byteArray, 0, byteArray.Length);
					 dataStream.Close();

					 WebResponse response = request.GetResponse();
					 //console.log(((HttpWebResponse)response).StatusDescription);
					 dataStream = response.GetResponseStream();
					 StreamReader reader = new StreamReader(dataStream);
					 string responseFromServer = reader.ReadToEnd();
					 reader.Close();
					 dataStream.Close();
					 response.Close();
					 return responseFromServer;
				}
				catch (Exception e)
				{
					 return e.Message;
				}
		  }

		  public Network(string theUrl)
		  {
				Url = theUrl;
		  }
		  public string Url { get; set; }
	 }
}
