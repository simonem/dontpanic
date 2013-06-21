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

		private TcpClient tcpclnt;
		private bool ready;

		/**
		 * Instatiates  a tcp client made to communicate with the nodejs server.
		 */
		public SClient ()
		{
			tcpclnt = new TcpClient();
			Log.Debug("Connecting....");

			//server ipadress
			tcpclnt.Connect ("127.0.0.1",6969);

			Log.Debug("Connected");
			ready = true;

		}

		/**
		 * The basic method used for transmitting to the server and reading the response
		 * dont use this method to communicate with the server, use other methods in the SClient class
		 * 
		 * takes the provided string msg and translates it to bytes in ASCII so it can be sendt to the server
		 * then uses a streamreader and reads a line from the stream and returns that line.
		 */
		private string request(string msg){
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


		/** Gets the newest gamecontainer object from the server
		 * returns a GameCont object  
		 */
		public GameCont getGameInfo(){

			string gamecontstring = request ("gameinfo");

			GameCont gamecont = JsonConvert.DeserializeObject<GameCont> (gamecontstring);

			return gamecont;
		}

		/**
		 * makes a json string and sends it to the server
		 * calling this will execute a move command on the provided player and attempt to move it to the provided node,
		 * at the moment there is no easy way to know if the move was successful before the next gamecont object is fetched from the server
		 */
		public void move(int player, int node){
			string msg = "{ \"command\": \"move_player\", ";
			msg = msg + "\"player_id\": " + player + ", ";
			msg = msg + "\"node\": " + node + " }";

			request (msg);

			// { "command": "thecommand" 
			// { "move": (int)node }



		}

		/**
		 * makes a json string and sends it to the server via the request method
		 * calling this will execute a decrease panic command to the provided zone on the server.
		 * at the moment there is no easy way to know if the decrease panic was succesful before the next gamecont object is fetched from the server
		 */
		public void decpanic(int zone){
			string msg = "{ \"command\": \"decrease_panic\", ";
			msg = msg + "\"zone\": " + zone + ", ";
			msg = msg + "\"szone\": " + zone + " }";

			request (msg);


		}
		/**
		 * makes a json string and sends it to the server via the request method
		 * calling this will execute a move peope command between the 2 zones on the server.
		 * at the momen there is no easy way to know if the move was succesful untill before the next gamecont object is fetched from the server
		 */
		public void movePeople(int fzone, int tzone){
			string msg = "{ \"command\": \"move_people\", ";
			msg = msg + "\"fzone\": " + fzone + ", ";
			msg = msg + "\"tzone\": " + tzone + " }";

			request (msg);
			


		}
	
		/**
		 * basic method to check if the client is transmitting to prevent it from sending several requests at once
		 * i made this because: during some testing the other methods seemed to be conflicting with regular once each second update
		 * the messages seemed to overlap if there was an event just beeing called right before the update, on the other hand, it seems to work fine if and event 
		 * is called during the update
		 */
		public bool isReady(){
			if (ready) {
				return true;
			}
			return false;
		}



	
	}
}

