using System;
using Sifteo;


namespace Dontpanic
{
	/**
	 * This object is made to only fit the neccecary info for keeping the cubes updated 
	 * if this class is to be changed the gameinfo object made in the engine.js on the server require the same change
	 * otherwise the JSON deserializer wont like it.
	 */
	public class GameCont
	{
		public int activePlayer;
		public int actionsLeft;
		public int timer;
		public Player[] players;
		public Zone[] zones;



		public GameCont ()
		{

		}
		public GameCont(int activePlayer, int actionsLeft, int timer, Player[] players, Zone[] zones){
			this.activePlayer = activePlayer;
			this.actionsLeft = actionsLeft;
			this.timer = timer;
			this.players = players;
			this.zones = zones;
		}
		public int getActivePlayer(){
			return activePlayer;
		}
		public int getActionsLeft(){
			return actionsLeft;
 		}
		public int getTimer(){
			return timer;
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

			           
	}
	/**
	 * this class is just to contain info about a player
	 */
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
	/**
	 * this class is just to contain info about a zone
	 */
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


