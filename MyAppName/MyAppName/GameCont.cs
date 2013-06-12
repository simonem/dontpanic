using System;
using Sifteo;


namespace GameContainer
{
	public class GameCont
	{
		int activePlayer;
		Player[] players;
		Zone[] zones;

		public GameCont ()
		{

		}
		public GameCont(int activePlayer, Player[] players, Zone[] zones){
			this.activePlayer = activePlayer;
			this.players = players;
			this.zones = zones;
		}
		public int getActivePlayer(){
			return activePlayer;
		}
		public Player getPlayer(int player){
			if (player>=0 && player < this.players.Length) {
				return players [player];
			}
			return null;
		}
		public Zone getZone(int zone){
			if (zone >=0 && zone < zones.Length) {

				return zones [zone];
			}
			return null;
		}
	}
	public class Player
	{
		string role;
		int nodeid;
		int[] zones;


		public Player(){

		}
		public Player(string grole, int gnodeid, int[] gzones){
			role = grole;
			nodeid = gnodeid;
			zones = gzones;
		}
		public string getRole(){
			return role;

		}
		public int getNodeid(){
			return nodeid;
		}
		public int getZone(int zone){
			if (zone>=0 && zone < zones.Length) {
				return zones [zone];
			}
			return -1;

		}
		
	}

	public class Zone
	{
		int panic;
		int people;

		public Zone()
		{

		}
		public Zone(int gpeople, int gpanic){
			panic = gpanic;
			people = gpeople;
		}
		public int getPanic(){
			return panic;
		}
		public int getPeople(){
			return people;
		}

	}



}


