using System;
using Sifteo;


namespace Dontpanic
{
	public class GameCont
	{
		public int activePlayer;
		public Player[] players;
		public Zone[] zones;

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
			if (player>=0 && player < this.players.Length) 
			{
				return players [player];
			}
			return null;
		}
		public Zone getZone(int zone){
			
			if (zone >=0 && zone < this.zones.Length)
			{			                                            

				return zones [zone];
			}
			return null;
		}
		public void print(){

			Log.Debug ("activeplayer: " + this.activePlayer);
			Log.Debug ("Players: " + this.players[0].getRole());
			Log.Debug ("Zones: " + this.zones[0].getPeople());
		}


			           
	}
	public class Player
	{
		public string role ;
		public int nodeid;
		
		public int[] zones;
	

		


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
		public int panic;
		public int people;


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


