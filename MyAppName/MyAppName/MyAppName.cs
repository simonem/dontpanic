using Sifteo;
using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using CClient;
using CubeTyper;
using GameContainer;
using CubeInfoContainer;

namespace MyAppName
{
  public class MyAppName : BaseApp
  {


		Typer typer = new Typer();
		SClient scli;
		GameCont gameContainer;
		Cube[] cubes;
		int frame = 20;
	
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
		
		scli = new SClient ();
    }



	

    override public void Tick()
    {
			 

			if (scli.isReady() && frame >= 20) {
				frame = 0;
				gameContainer = scli.getGameInfo ();

				//gameContainer.print ();

				for(int i = 0 ; i < 4 && i < cubes.Length; i++){ 
					new CubeInfo ().Draw (cubes[i], i, gameContainer);
				}


			}
		

			foreach (Cube cube in CubeSet) {


				/*
				if(cube.ButtonIsPressed){

					//CubeInfo cube1 = scli.Cube ();



					typer.printText (cube, "cm", 20, 20);
					//typer.printText (cube, "driver", 20, 40);
					//typer.printText (cube, "operations expert", 20, 60);

					cube.Paint ();


					//cube1.Draw (cube);

		

				}*/
				//Log.Debug ("" + cube.Tilt.Length + "" + cube.Tilt[0] + "" + cube.Tilt[1] + "" + cube.Tilt[2]);
			}
			frame++;


    }

		

    // development mode only
    // start MyAppName as an executable and run it, waiting for Siftrunner to connect
    static void Main(string[] args) { 
			new MyAppName().Run();


		}
	}
	
}


