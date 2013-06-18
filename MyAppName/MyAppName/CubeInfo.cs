using System;
using Sifteo;
using Newtonsoft.Json;


namespace Dontpanic
{
	public class CubeInfo
	{
		
		public int fzone = -1;
		public int amount = 0;
		public int onTheMove = 0;

		public CubeInfo()
		{

		}

		public void drawZone(Cube cube, Zone zone, int x, int y, int zoneid){
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


			cube.FillRect (zonecolor,  (x*Cube.SCREEN_WIDTH  /4), (y * Cube.SCREEN_HEIGHT / 4), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 4);
			if(zoneid == fzone){

				typer.printText (invzonecolor, cube, "" + (zone.getPeople() - onTheMove), (x * Cube.SCREEN_WIDTH  /4) + (Cube.SCREEN_WIDTH/8 - typer.getIntLength( "" + zone.getPeople())/2),  (y * Cube.SCREEN_HEIGHT / 4));
			}
			else{
				typer.printText (invzonecolor, cube, "" + zone.getPeople(), (x * Cube.SCREEN_WIDTH  /4) + (Cube.SCREEN_WIDTH/8 - typer.getIntLength( "" + zone.getPeople())/2),  (y * Cube.SCREEN_HEIGHT / 4));
			}


		}

		public void Draw(Cube cube, int player, GameCont GC){




			cube.ClearEvents ();
			Typer typer = new Typer ();
			// Draw background
			// maybe draw an image as bg template 
			//cube.FillRect (new Color (255, 255, 255), 0, 0, Cube.SCREEN_WIDTH, Cube.SCREEN_HEIGHT);
			if (!GC.getPlayer (player).Equals (null)) {

			
				if (player == GC.getActivePlayer ()) {
					cube.FillScreen (new Color(100, 100,100));
				} else {
					cube.FillScreen (new Color(255,255,255));
				}
				// Draw playerinfo

				// Draw role
				typer.printText (cube, GC.getPlayer (player).getRole (), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 4);

				// Draw nodeid
				typer.printText (cube, "" + GC.getPlayer (player).getNodeid (), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 2);
			

				/*/
				// Draw zones 
				for (int i = 0; i < 2; i++) {
					for (int o = 0; o < 2; o++) {

						int zone = GC.getPlayer (player).getZone ((i*2)+(o*1));
						if (zone == -1) {
							break;
						} else {

							int R = (int)(255 * ((double)GC.getZone(zone).getPanic() / (double)50));
							int G = 0;
							int B = 0;
							Color zonecolor = new Color (R, G, B);
							Color invzonecolor = new Color (255 - R, 255 - G, 255 - B);


							cube.FillRect (zonecolor,i * (3 *  Cube.SCREEN_WIDTH / 4 ), o * (3 * Cube.SCREEN_HEIGHT / 4), Cube.SCREEN_WIDTH / 4, Cube.SCREEN_HEIGHT / 4);
							typer.printText (invzonecolor, cube,  "" + GC.getZone (zone).getPeople (), i * (3*Cube.SCREEN_WIDTH  /4), o * (3 * Cube.SCREEN_HEIGHT / 4));

							typer.printText (invzonecolor, cube, "" + GC.getZone (zone).getPanic (),i * (3* Cube.SCREEN_WIDTH /4), 15 + o * (3 * Cube.SCREEN_HEIGHT / 4));
						}

					}
				}

				/*/

				// harcoded draw zones
				switch (GC.getPlayer (player).getNodeid ()) {

				case 0:

					drawZone (cube, GC.getZone (0), 2, 0, 0);
					drawZone (cube, GC.getZone (6), 3, 1, 6);
					break;

				case 1:
					drawZone (cube, GC.getZone (0), 3, 3, 0);
					drawZone (cube, GC.getZone (1), 3, 1, 1);
					break;
				case 2:
					drawZone (cube, GC.getZone (0), 0, 2, 0);
					drawZone (cube, GC.getZone (1), 0, 0, 1);
					drawZone (cube, GC.getZone (2), 3, 1, 2);
					drawZone (cube, GC.getZone (6), 1, 3, 6);

					break;

				case 3:
					drawZone (cube, GC.getZone (1), 0, 3, 1);
					drawZone (cube, GC.getZone (2), 2, 3, 2);
					drawZone (cube, GC.getZone (3), 3, 2, 3);

					break;
				
				case 4:
					drawZone (cube, GC.getZone (4), 0, 2, 4);

					break;
				case 5:
					drawZone (cube, GC.getZone (4), 1, 0, 4);
					drawZone (cube, GC.getZone (5), 0, 1, 5);
					break;

				case 6: 
					drawZone (cube, GC.getZone (2), 0, 1, 2);
					drawZone (cube, GC.getZone (3), 1, 0, 3);
					drawZone (cube, GC.getZone (4), 3, 1, 4);
					drawZone (cube, GC.getZone (5), 2, 3, 5);
					break;

				case 7:
					drawZone (cube, GC.getZone (2), 1, 0, 2);
					drawZone (cube, GC.getZone (5), 3, 1, 5);
					drawZone (cube, GC.getZone (6), 0, 0, 6);
					break;

				case 8:
					drawZone (cube, GC.getZone (3), 0, 3, 3);
					drawZone (cube, GC.getZone (4), 2, 3, 4);

					break;



				}






				/*/
				// new Draw zones
				Player theplayer = GC.getPlayer (player);


				// sort in corners

				int[] corner00 = new int[2];
				int[] corner01 = new int[2];
				int[] corner10 = new int[2];
				int[] corner11 = new int[2];



				for (int i = 0; i < GC.getPlayer(player).zones.Length; i++) {

					Zone zone = GC.getZone( GC.getPlayer (player).getZone (i));

					if (zone.getX () >= theplayer.getX ()) { //  zone x > player x

						if (zone.getY () >= theplayer.getY ()) { // zone y > player y
							// bottom rigth corner
							if(corner11[0] 


						} else { // player y > zone y 
							// top right corner 



						}



					} else { //  player x > zone x
						if (zone.getY () >= theplayer.getY ()) { // zone y > player y
							// bottom left corner



						} else { // player y > zone y 
							// top left corner


						}


					}



				}/*/
				cube.Paint ();



			}

		}


	}
}

