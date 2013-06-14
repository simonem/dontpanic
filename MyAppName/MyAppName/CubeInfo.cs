using System;
using Sifteo;
using Newtonsoft.Json;
using CubeTyper;
using GameContainer;


namespace CubeInfoContainer
{
	public class CubeInfo
	{
	

		public CubeInfo()
		{

		}

		public void Draw(Cube cube, int player, GameCont GC){




			cube.ClearEvents ();
			Typer typer = new Typer ();
			// Draw background
			// TODO: draw different bgcolor if cube is active player 
			// maybe draw an image as bg template 
			//cube.FillRect (new Color (255, 255, 255), 0, 0, Cube.SCREEN_WIDTH, Cube.SCREEN_HEIGHT);
			if (!GC.getPlayer (player).Equals (null)) {

			
				if (player == GC.getActivePlayer ()) {
					cube.FillScreen (new Color(255, 0,0));
				} else {
					cube.FillScreen (new Color(255,255,255));
				}
				// Draw playerinfo

				// Draw role
				typer.printText (cube, GC.getPlayer (player).getRole (), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 4);

				// Draw nodeid
				typer.printText (cube, "" + GC.getPlayer (player).getNodeid (), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 2);
			


				// Draw zones 
				for (int i = 0; i < 2; i++) {
					for (int o = 0; o < 2; o++) {

						int zone = GC.getPlayer (player).getZone ((i*2)+(o*1));
						if (zone == -1) {
							break;
						} else {

							int R = (int)(255 * ((double)GC.getZone(zone).getPanic() / (double)50));
							Log.Debug ("" + (int)(200 * ((double)GC.getZone(zone).getPanic() / 50)));
							int G = 0;
							int B = 0;
							Color zonecolor = new Color (R, G, B);
							Color invzonecolor = new Color (255 - R, 255 - G, 255 - B);


							cube.FillRect (zonecolor, 0 + i * (Cube.SCREEN_WIDTH - 20), 0 + o * (3 * Cube.SCREEN_HEIGHT / 4), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 4);
							typer.printText (invzonecolor, cube,  "" + GC.getZone (zone).getPeople (), 0 + i * (Cube.SCREEN_WIDTH - 20), 0 + o * (3 * Cube.SCREEN_HEIGHT / 4));

							typer.printText (invzonecolor, cube, "" + GC.getZone (zone).getPanic (), 0 + i * (Cube.SCREEN_WIDTH - 20), 12 + o * (3 * Cube.SCREEN_HEIGHT / 4));
						}

					}
				}

				cube.Paint ();
			}

		}


	}
}

