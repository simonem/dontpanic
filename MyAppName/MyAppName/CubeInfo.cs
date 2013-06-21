using System;
using Sifteo;
using Newtonsoft.Json;


namespace Dontpanic
{
	public class CubeInfo
	{

		// fzone is the zone currently being used by the move people cube
		// amount is how many times the cube wants to move people in one go  THIS MIGHT BE REMOVED AT A LATER STAGE DEPENDING ON THE RULES OF THE GAME
		// onTheMove
		public int fzone = -1; 
		public int amount = 0;
		public int onTheMove = 0;


		public CubeInfo()
		{

		}


		/**
		 * Draws a zone on the provided cube, zone is the zone to be drawn, pos is which of the 4 sides to draw on
		 * where 1 is top, 2 is left side, 3 is right side and 4 is the bottom. the zoneid is used to draw if someone is currently beeing moved from that zone
		 */
		public void drawZone(Cube cube, Zone zone, int pos, int zoneid){
			Typer typer = new Typer ();
			Color zonecolor = new Color (0, 0, 0);
			Color invzonecolor = new Color (255 , 255, 255);
			double panicpercent =  (double)zone.getPanic()/(double)50;
			if (panicpercent >= (double)0.75) {


			} else if (panicpercent >= (double)0.5) {
				zonecolor = new Color (255, 0, 0);
				invzonecolor = new Color (0, 255, 255);
			}
			else if (panicpercent >= (double)0.25){
				zonecolor =  new Color(255,255,0);
				invzonecolor = new Color (0, 0, 255);
			}
			else {
				zonecolor = new Color (0, 255, 0);
				invzonecolor = new Color (255, 0, 255);
			}

			int x = 0;
			int y = 0;
			int w = 1;
			int h = 1;
			switch(pos){
			case 1:
				x = 1;
				w = 2;
				break;
			case 2:
				y = 1;
				h = 2;
				break;
			case 3:
				x = 3;
				y = 1;
				h = 2;
				break;
			case 4:
				x = 1;
				y = 3;
				w = 2;
				break;
			}



			cube.FillRect (zonecolor,  (x*Cube.SCREEN_WIDTH  /4), (y * Cube.SCREEN_HEIGHT / 4), w * Cube.SCREEN_WIDTH / 4, h * Cube.SCREEN_HEIGHT / 4);


			if(zoneid == fzone){

				typer.printText (invzonecolor, cube, "" + (zone.getPeople() - onTheMove),(x * Cube.SCREEN_WIDTH  /4) + ((w) * Cube.SCREEN_WIDTH/8) - (typer.getIntLength( "" + zone.getPeople())/2),  (y * Cube.SCREEN_HEIGHT / 4) + ((h - 1) * Cube.SCREEN_HEIGHT / 8));
			}
			else{
				typer.printText (invzonecolor, cube, "" + zone.getPeople(), (x * Cube.SCREEN_WIDTH  /4) + ((w) * Cube.SCREEN_WIDTH/8) - (typer.getIntLength( "" + zone.getPeople())/2),  (y * Cube.SCREEN_HEIGHT / 4) + ((h - 1) * Cube.SCREEN_HEIGHT / 8));
			}


		}


		/** Draw method for the player cubes,
		 *  cube is the cube to be drawn on, player is the player to draw and the gamecontainer is used to get info about the player
		 *  such as if its the active player, the role, and so forth
		 */
		public void Draw(Cube cube, int player, GameCont GC){




			Typer typer = new Typer ();
			// Draw background
			// maybe draw an image as bg template 
			if (!GC.getPlayer (player).Equals (null)) {

			
				if (player == GC.getActivePlayer ()) {
					cube.FillScreen (new Color(255,255,255));
					typer.printText (cube, "" + GC.getActionsLeft (), 0, 0);
				} else {
					cube.FillScreen (new Color(100,100,100));
				}
				// Draw playerinfo
//
//				// Draw role    Change in engine.js if this is going to be used again
//				typer.printText (cube, GC.getPlayer (player).getRole (), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 4);
				// Drawing role as a image:
				cube.Image (GC.getPlayer (player).getRole (), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 4, 0, 0, 48, 48, 0, 0);


				// Draw nodeid
				typer.printText (cube, "" + GC.getPlayer (player).getNodeid (), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 2);


			

				// harcoded draw zones
				switch (GC.getPlayer (player).getNodeid ()) {

				case 0:

					drawZone (cube, GC.getZone (0), 1, 0);
					drawZone (cube, GC.getZone (6), 3, 6);
					break;

				case 1:
					drawZone (cube, GC.getZone (0), 4, 0);
					drawZone (cube, GC.getZone (1), 3, 1);
					break;
				case 2:
					drawZone (cube, GC.getZone (0), 2, 0);
					drawZone (cube, GC.getZone (1), 1, 1);
					drawZone (cube, GC.getZone (2), 3, 2);
					drawZone (cube, GC.getZone (6), 4, 6);

					break;

				case 3:
					drawZone (cube, GC.getZone (1), 2, 1);
					drawZone (cube, GC.getZone (2), 4, 2);
					drawZone (cube, GC.getZone (3), 3, 3);

					break;
				
				case 4:
					drawZone (cube, GC.getZone (4), 2, 4);

					break;
				case 5:
					drawZone (cube, GC.getZone (4), 1, 4);
					drawZone (cube, GC.getZone (5), 2, 5);
					break;

				case 6: 
					drawZone (cube, GC.getZone (2), 2, 2);
					drawZone (cube, GC.getZone (3), 1, 3);
					drawZone (cube, GC.getZone (4), 3, 4);
					drawZone (cube, GC.getZone (5), 4, 5);
					break;

				case 7:
					drawZone (cube, GC.getZone (2), 1, 2);
					drawZone (cube, GC.getZone (5), 3, 5);
					drawZone (cube, GC.getZone (6), 2, 6);
					break;

				case 8:
					drawZone (cube, GC.getZone (3), 3, 3);
					drawZone (cube, GC.getZone (4), 4, 4);

					break;



				}
				cube.Paint ();

			}

		}


	}
}

