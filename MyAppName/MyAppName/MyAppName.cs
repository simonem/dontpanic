using Sifteo;
using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;


namespace Dontpanic
{
  public class MyAppName : BaseApp
  {


		Typer typer = new Typer();
		SClient scli;
		GameCont gameContainer;
		Cube[] cubes;
		int frame = 20;
		Sound mymusic;

		int fzone = -1;
		int amount = 0;
	
    override public int FrameRate
    {
      get { return 20; }
    }

    // called during intitialization, before the game has started to run
    override public void Setup()
    {

		cubes = CubeSet.toArray();
		
      	Log.Debug("Setup()");
		foreach (Cube cube in CubeSet) {

				cube.FillRect (new Color (255, 255, 255), 0, 0, Cube.SCREEN_WIDTH, Cube.SCREEN_HEIGHT);
				

				cube.Paint ();


			}
			cubes[4].NeighborAddEvent += OnDecreasePanic; // adding event handler to the dec panic cube
			cubes[4].FillScreen(new Color(255,100,100));
			cubes [4].Paint ();

			cubes[5].NeighborAddEvent += OnMovePeople; // adding event handler to the move people cube
			cubes[5].FillScreen(new Color(100,100,0));
			cubes [5].Paint ();
		
		scli = new SClient ();
    }



	

    override public void Tick()
    {


			 

			if (scli.isReady() && frame >= 20) {
				frame = 0;



				gameContainer = scli.getGameInfo ();

				if(cubes[gameContainer.getActivePlayer()].ButtonIsPressed){
					Cube cube = cubes [gameContainer.getActivePlayer()];
					int node = cube.Tilt [0] * 3 + cube.Tilt [1];
					scli.move(gameContainer.getActivePlayer(), node);
				}

				//gameContainer.print ();

				for(int i = 0 ; i < 4 && i < cubes.Length; i++){ 
					new CubeInfo ().Draw (cubes[i], i, gameContainer);
				}


			}
			/*/

			foreach (Cube cube in CubeSet) {

				cube.ClearEvents ();
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


		public void OnDecreasePanic (Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2){ // occurs when the panic dec cube has been connected with another cube.

			int player = -1;
			for(int i = 0 ; i < cubes.Length; i++){
				if (cubes[i].Equals(cube2)){
					player = i;
					break;
				}
			}
			if(gameContainer.getActivePlayer() == player){


				int zone = FindZone (gameContainer.getPlayer(player).getNodeid(), side2);
				scli.decpanic (zone);


			}

		}
		public void OnMovePeople(Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2)  {

		
			Sound s = this.Sounds.CreateSound("gliss");
				//Sounds.CreateSound("gliss");
			s.Play(1);



			int player = -1;
			for(int i = 0 ; i < cubes.Length; i++){
				if (cubes[i].Equals(cube2)){
					player = i;
					break;
				}
			}




			if (gameContainer.getActivePlayer () == player) {

				int zone = FindZone (gameContainer.getPlayer(player).getNodeid(), side2);

			
				if (zone == fzone || fzone == -1) {

					int eachmove = 5;
					if (gameContainer.getPlayer (player).getRole () == "d") {
						eachmove = 10;
					}

					if (!(gameContainer.getZone (zone).getPeople() - (eachmove * amount) <= 0)) {

						amount ++;
						fzone = zone;


						cube1.FillScreen(new Color(100,100,0));
						typer.printText (cube1, "" + zone, 20, 20);
						typer.printText (cube1, "" + (eachmove * amount), 20, 40);
						cube1.Paint ();
					}





				} else {

					for (int i = 0; i < amount; i++) {
						scli.movePeople (fzone, zone);

					}
					amount = 0;
					fzone = -1;
					cube1.FillScreen(new Color(100,100,0));
					cube1.Paint ();
				}





			}



		}

	
	}
}


