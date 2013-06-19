using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using Sifteo;
using Newtonsoft.Json;



namespace Dontpanic
{
	public class SClient
	{

		TcpClient tcpclnt;
		private bool ready;


		public SClient ()
		{
			tcpclnt = new TcpClient();
			Log.Debug("Connecting....");

			//server ipadress
			tcpclnt.Connect ("127.0.0.1",6969);

			Log.Debug("Connected");
			ready = true;

		}
		public string request(string msg){
			try{
				ready = false;

				Log.Debug("Sending: " + msg);

				ASCIIEncoding asen = new ASCIIEncoding();

				byte[] bb = asen.GetBytes(msg); 

				Stream stm = tcpclnt.GetStream();

				stm.Write(bb, 0, bb.Length);

				string str = "";
				StreamReader reader = new StreamReader(stm);

				str = reader.ReadLine();

				Log.Debug(str);
				ready = true;

				return str;
			}
			catch(Exception e) {
				Log.Debug ("Error..." + e.StackTrace);
			}
			return "fail";
		}

		public void Close(){
			tcpclnt.Close ();
		}


		// gets the newest gamecontainer object from the server
		public GameCont getGameInfo(){

			string gamecontstring = request ("gameinfo");

			GameCont gamecont = JsonConvert.DeserializeObject<GameCont> (gamecontstring);

			return gamecont;
		}

		public void move(int player, int node){
			string msg = "{ \"command\": \"move_player\", ";
			msg = msg + "\"player_id\": " + player + ", ";
			msg = msg + "\"node\": " + node + " }";

			request (msg);

			// { "command": "thecommand" 
			// { "move": (int)node }



		}

		public void decpanic(int zone){
			string msg = "{ \"command\": \"decrease_panic\", ";
			msg = msg + "\"zone\": " + zone + ", ";
			msg = msg + "\"szone\": " + zone + " }";

			request (msg);


		}
		public void movePeople(int fzone, int tzone){
			string msg = "{ \"command\": \"move_people\", ";
			msg = msg + "\"fzone\": " + fzone + ", ";
			msg = msg + "\"tzone\": " + tzone + " }";

			request (msg);
			


		}
	

		public bool isReady(){
			if (ready) {
				return true;
			}
			return false;
		}



	
	}
}

