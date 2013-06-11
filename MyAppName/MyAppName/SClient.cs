using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using Sifteo;
using Newtonsoft.Json;
using CubeInfoContainer;




namespace CClient
{
	public class SClient
	{
		//string role;

		public SClient ()
		{


		}
		public string request(string msg){
			try{
				TcpClient tcpclnt = new TcpClient();
				Log.Debug("Connecting....");

				//server ipadress
				tcpclnt.Connect ("127.0.0.1",6969);

				Log.Debug("Connected");

				Log.Debug("Sending: " + msg);

				ASCIIEncoding asen = new ASCIIEncoding();

				byte[] bb = asen.GetBytes(msg); 

				Stream stm = tcpclnt.GetStream();


				stm.Write(bb, 0, bb.Length);

				byte[] ba = new byte[100];
				int k = stm.Read(ba, 0, 100);
				string str = "";
				for(int i = 0; i < k ; i++){
					str += (Convert.ToChar(ba[i]));
				}
				Log.Debug(str);

				tcpclnt.Close ();
				return str;
			}
			catch(Exception e) {
				Log.Debug ("Error..." + e.StackTrace);
			}
			return "fail";
		}

		public string nodeidtest(){


			string nodeid = request ("nodeid");

			return nodeid;
		}

		public CubeInfo Cube(){

			string cubestring = request ("player");

			CubeInfo cube = JsonConvert.DeserializeObject<CubeInfo> (cubestring); 

			return cube;
		}


	
	}
}

