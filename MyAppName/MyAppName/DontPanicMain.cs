using Sifteo;
using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;


namespace Dontpanic
{
	public class DontPanicMain : BaseApp
	{


		Typer typer = new Typer();
		SClient scli;
		GameCont gameContainer;
		Cube[] cubes;
		CubeInfo cubeHandler = new CubeInfo();
		int frame = 20;
		Sound movePlayer;
		Sound timer10sec;
		Sound decPanic;
		Sound movePeople;

		/**
		 * this variable is used for selecting the source Y on the images when there are other languages available 
		 */
		int language = 1;

		/**
		 * this holds the zoneid of the zone that is connected to the decrease panic cube, so it does not have to be calculated on each step
		 */
		int connectedZonePanic = -1;

		/**
		 * the framerate is the number of times the Tick() is called each second,
		 * ive kept it at 20 and made a workaround so the cubes repaint themselves each second in case there would be some other use 
		 * for having a higher framerate in the future.
		 */
		override public int FrameRate
		{
			get { return 20; }
		}

	  	/**
	  	 * called during intitialization, before the game has started to run
	  	 */
  		override public void Setup()
 	 	{
			/**
			 * Creating the sounds in the game, for changing a sound you would want to be doing it here
			 */
			movePlayer = Sounds.CreateSound ("moving_player");
			timer10sec = Sounds.CreateSound ("10sec_left");
			decPanic = Sounds.CreateSound ("dec_panic");
			movePeople = Sounds.CreateSound("move_people");


			cubes = CubeSet.toArray();
		
      		Log.Debug("Setup()");
			foreach (Cube cube in CubeSet) {

				cube.FillRect (new Color (255, 255, 255), 0, 0, Cube.SCREEN_WIDTH, Cube.SCREEN_HEIGHT);
				

				cube.Paint ();


			}
			for(int i = 0; i < 4; i++){
				cubes[i].ButtonEvent += OnMovePlayerClick;
			}

			// this cube (cubes[4]) is the cube that will be used to decrease panic in zones.
			cubes[4].NeighborAddEvent += OnDecreasePanicConnect; // adding event handler to the dec panic cube
			cubes[4].FillScreen(new Color(255,100,100)); // adding a bg color
			cubes [4].Paint ();

			// this cube (cubes[5]) is the cube that will be used to move people from one zone to another.
			cubes[5].NeighborAddEvent += OnMovePeopleConnect; // adding event handlers to the move people cube
			cubes [5].ButtonEvent += OnCancelMoveClick;
			cubes[5].NeighborRemoveEvent += OnMovePeopleDetach;
			cubes [5].FillScreen (new Color(100,100,0)); // adding a bg color
			cubes [5].Image ("DPBump", 0, 0, 0, language * 128, 128, 128, 0, 0);
			cubes [5].Paint ();
		
			scli = new SClient ();
    	}



	
		/**
		 * basic update function, its called many times a second as spesified by the framerate.
		 */
    	override public void Tick()
    	{

			if (scli.isReady() && frame >= 20) {
				frame = 0;

				gameContainer = scli.getGameInfo ();

				if(gameContainer.getTimer() < 10){
					if(!timer10sec.IsPlaying){
						timer10sec.Play (1);
					}
				}

				for(int i = 0 ; i < 4 && i < cubes.Length; i++){ 
					cubeHandler.Draw (cubes[i], i, gameContainer);
				}


			}
			/*/

			foreach (Cube cube in CubeSet) {

				cube.FillScreen (new Color(255,255,255));
				typer.printText (cube, "" + cube.Tilt [0] + " " + cube.Tilt [1], 20, 20);
				int node = cube.Tilt [0] * 3 + cube.Tilt [1];
				typer.printText (cube, "" + node, 20, 50);


				cube.Paint ();

				if(cube.ButtonIsPressed){

					//CubeInfo cube1 = scli.Cube ();

					//typer.printText (cube, "cm", 20, 10);
					//typer.printText (cube, "d", 20, 50);

					//typer.printText (cube, "oe f", 20, 90);
					//typer.printText (cube, "driver", 20, 40);
					//typer.printText (cube, "operations expert", 20, 60);

					//cube.Paint ();
					//cube1.Draw (cube);

				}
				//Log.Debug ("" + cube.Tilt.Length + "" + cube.Tilt[0] + "" + cube.Tilt[1] + "" + cube.Tilt[2]);
			}/*/
			frame++;


 		}
		/**
		 * This method takes a nodeid and a side of a cube and returns the id of the zone 
		 * that lies on that side of the node, any changes to the map needs to be made here aswell
		 */
		public int FindZone(int node, Cube.Side cubeside){
			switch (node) {

				case 0:
				if(cubeside == Cube.Side.TOP){
					return 0;
				}
				if(cubeside == Cube.Side.RIGHT){
					return 6;
				}
				break;

				case 1:
				if(cubeside == Cube.Side.RIGHT){
					return 1;
				}
				if(cubeside == Cube.Side.BOTTOM){
					return 0;
				}
				break;

				case 2:
				if(cubeside == Cube.Side.TOP){
					return 1;
				}
				if(cubeside == Cube.Side.LEFT){
					return 0;
				}
				if(cubeside == Cube.Side.RIGHT){
					return 2;
				}
				if(cubeside == Cube.Side.BOTTOM){
					return 6;
				}
				break;

				case 3:
				if(cubeside == Cube.Side.LEFT){
					return 1;
				}
				if(cubeside == Cube.Side.BOTTOM){
					return 2;
				}
				if(cubeside == Cube.Side.RIGHT){
					return 3;
				}
				break;

				case 4:
				if(cubeside == Cube.Side.LEFT){
					return 4;
				}
				break;

				case 5:
				if(cubeside == Cube.Side.TOP){
					return 4;
				}
				if(cubeside == Cube.Side.LEFT){
					return 5;
				}
				break;

				case 6: 
				if(cubeside == Cube.Side.TOP){
					return 3;
				}
				if(cubeside == Cube.Side.LEFT){
					return 2;
				}
				if(cubeside == Cube.Side.RIGHT){
					return 4;
				}
				if(cubeside == Cube.Side.BOTTOM){
					return 5;
				}
				break;

				case 7:
				if(cubeside == Cube.Side.TOP){
					return 2;
				}
				if(cubeside == Cube.Side.LEFT){
					return 6;
				}
				if(cubeside == Cube.Side.RIGHT){
					return 5;
				}
				break;

				case 8:
				if(cubeside == Cube.Side.LEFT){
					return 3;
				}
				if(cubeside == Cube.Side.BOTTOM){
					return 4;
				}
				break;
			}
			return -1;

		}


		/**
		 * event called when a player coube is pressed
		 * each time a player cube is pressed it will check if its the active player. 
		 * and if it is then it will read the angle of the cube, and figure out which node socet the cube is on
		 * after that it will attemt to move by sending a message to the server
		 * it will not know if the move was successful untill the next fetching of the gamecontainer object
		 */
		public void OnMovePlayerClick(Cube c, bool pressed){


			if(cubes[gameContainer.getActivePlayer()].Equals(c) && pressed){


				int node = c.Tilt [0] * 3 + c.Tilt [1];
				scli.move(gameContainer.getActivePlayer(), node);
				if(!movePlayer.IsPlaying){
					movePlayer.Play (1);
				}
			}	
		}

		/**
		 * used to cancel moving people after picking them up
		 * it does this by resetting the amount and fzone variables and repainting the cube 
		 * as it was after the setup
		 */
		public void OnCancelMoveClick(Cube c, bool pressed){
			if(pressed){
				cubeHandler.amount = 0;
				cubeHandler.fzone = -1;

				c.FillScreen (new Color(100,100,0));
				c.Image ("DPBump", 0, 0, 0, language * 128, 128, 128, 0, 0);
				c.Paint ();
			}

		}

		/**
		 * Event handler for when the decrease panic cube has been connected with another cube
		 * 
		 */
		public void OnDecreasePanicConnect (Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2){ 

			// finds the player accosiated with cube2
			int player = -1;
			for(int i = 0 ; i < cubes.Length; i++){
				if (cubes[i].Equals(cube2)){
					player = i;
					break;
				}
			}
			if(gameContainer.getActivePlayer() == player){


				int zone = FindZone (gameContainer.getPlayer(player).getNodeid(), side2);
				cube1.FillScreen(new Color(255,100,100));

				int removed = 5;
				if (gameContainer.getPlayer (player).getRole () == "cm") {
					removed = 10;
				}
				int previouspanic = gameContainer.getZone (zone).getPanic ();

				if(removed > previouspanic){
					removed = previouspanic;
				}

				if(gameContainer.getActionsLeft() > 0){
					
					cube1.Image ("DPPanic", 0, 0, 0, language * 128, 128, 128, 0, 0);
					typer.printText (cube1, "" + removed , 80, 100);
					typer.printText (cube1, "" +  previouspanic, 50, 40);
					cube1.Paint ();
					cube1.ClearEvents ();
					cube1.ButtonEvent += OnDecreasePanicPush;
					cube1.NeighborRemoveEvent += OnDecreasePanicDetach;
					connectedZonePanic = zone;
				}
				else {

				}

			}

		}
		/**
		 * Event handler for when the decrease panic cube has been pushed
		 * sends a message to the server to decrease panic
		 */

		public void OnDecreasePanicPush(Cube c, bool pressed){

			c.ClearEvents ();
			c.NeighborRemoveEvent += OnDecreasePanicDetach;

			c.FillScreen(new Color(255,100,100));
			
			c.Image ("faceDP", 0, 0, 0, 0, 128, 128, 0, 0);
			c.Paint ();
			if(!decPanic.IsPlaying){
				decPanic.Play (1);
			}

			scli.decpanic (connectedZonePanic);


		}
		/**
		 * Event handler for when the decrease panic cube is detached from a playercube
		 * 
		 */
		public void OnDecreasePanicDetach(Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2)  {
			connectedZonePanic = -1;
			cube1.FillScreen(new Color(255,100,100));
			cube1.Image ("DPPanic2", 0, 0, 0, language * 128, 128, 128, 0, 0);
			cube1.Paint ();
			cube1.ClearEvents ();
			cube1.NeighborAddEvent += OnDecreasePanicConnect;


		}
		/**
		 * Event handler for when the move people cube has been connected with another cube
		 * figures out if the cube its connected to is the active player then calculates what zone to move people from.
		 */
		public void OnMovePeopleConnect(Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2)  {
			// finds the player accosiated with cube2
			int player = -1;
			for(int i = 0 ; i < cubes.Length; i++){
				if (cubes[i].Equals(cube2)){
					player = i;
					break;
				}
			}

			if (gameContainer.getActivePlayer () == player) {

				int zone = FindZone (gameContainer.getPlayer(player).getNodeid(), side2);

			
				if (zone == cubeHandler.fzone || cubeHandler.fzone == -1) {

					int eachmove = 5;
					if (gameContainer.getPlayer (player).getRole () == "d") {
						eachmove = 10;
					}

					if (!(gameContainer.getZone (zone).getPeople() - (eachmove * cubeHandler.amount) <= 0)) {

						cubeHandler.amount ++;
						cubeHandler.fzone = zone;
						cubeHandler.onTheMove = (eachmove * cubeHandler.amount);


						cube1.FillScreen(new Color(100,100,0));
						//typer.printText (cube1, "" + zone, 20, 20);
						//typer.printText (cube1, "" + (eachmove * cubeHandler.amount), 20, 40);
						
						cube1.Image ("movePeople", 0, 0, 0, 0, 128, 128, 0, 0);
						cube1.Paint ();
					}

				} else {

					for (int i = 0; i < cubeHandler.amount; i++) {
						scli.movePeople (cubeHandler.fzone, zone);

					}

					cubeHandler.amount = 0;
					cubeHandler.fzone = -1;
					cube1.FillScreen(new Color(100,100,0));
					cube1.Image ("movePeople", 0, 0, 0, 0, 128, 128, 0, 0);
					cube1.Paint ();

					if (!movePeople.IsPlaying) {
						movePeople.Play (1);
					}
				}	
			}
		}

		/**Event handler for when the move people cube has been detached after moving people
		 * or after picking up people 
		 * 
		*/	
		public void OnMovePeopleDetach(Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2){
				
			if (cubeHandler.amount > 0) {
				
				cube1.FillScreen (new Color(100,100,0));

				cube1.Image ("DPBump2", 0, 0, 0, language *128, 128, 128, 0, 0);
				cube1.Paint ();


			} else {
				cube1.FillScreen (new Color(100,100,0));

				cube1.Image ("DPBump", 0, 0, 0, language*128, 128, 128, 0, 0);
				cube1.Paint ();
			}


		}

	
	}
}


