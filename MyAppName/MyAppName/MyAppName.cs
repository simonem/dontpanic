using Sifteo;
using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using CClient;
using CubeTyper;
using CubeInfoContainer;

namespace MyAppName
{
  public class MyAppName : BaseApp
  {
		Boolean posted = false;
	//	WebBrowser webBrowser1;
		Typer typer = new Typer();
		SClient scli;
	
    override public int FrameRate
    {

      get { return 10; }
    }

    // called during intitialization, before the game has started to run
    override public void Setup()
    {

		
      	Log.Debug("Setup()");
		int spriteYPos = 0;
		foreach (Cube cube in CubeSet) {
			cube.FillRect (new Color (255, 255, 255), 0, 0, Cube.SCREEN_WIDTH, Cube.SCREEN_HEIGHT);
			
				typer.printChar (cube, 'a', 0, 0);
				cube.Paint ();
			spriteYPos += Cube.SCREEN_HEIGHT;
		
			
			}
		
		scli = new SClient ();
    }



	

    override public void Tick()
    {


			foreach (Cube cube in CubeSet) {


				if(cube.Tilt[0] == 2 && !posted ){
					Log.Debug ("tilt is 2");
					//printChar(cube, 'B', 0, 20); 

				

					posted = true;

				}
				if(cube.ButtonIsPressed){

					CubeInfo cube1 = scli.Cube ();


					Log.Debug ("result: ");


					Log.Debug ("role: " + cube1.getRole());
					Log.Debug ("nodeid: " + cube1.getNodeid());
					//string test = scli.nodeidtest ();
					//Log.Debug ("nodeid" + test);
		

				}
				//cube.Tilt.Length();
				//Log.Debug ("" + cube.Tilt.Length + "" + cube.Tilt[0] + "" + cube.Tilt[1] + "" + cube.Tilt[2]);
			}
    }

		

    // development mode only
    // start MyAppName as an executable and run it, waiting for Siftrunner to connect
    static void Main(string[] args) { 
			new MyAppName().Run();


		}
	}
	
}


