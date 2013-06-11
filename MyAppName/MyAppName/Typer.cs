using System;
using Sifteo;

namespace CubeTyper
{
	public class Typer
	{
		public Typer ()
		{

		}


		public void printText(Cube cube, String text, int x, int y){
			int offset = 0;
			foreach(char c in text.ToLower().ToCharArray()){
				printChar(cube, c, x+offset, y);
				offset = offset + 9;
			}
		}
		public void printChar(Cube cube, char c, int cX,int cY){
			Color chr_clr = new Color (0, 0, 0);

			switch (c) {
			case 'a':
				cube.FillRect (chr_clr, cX + 0, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 8, 1, 1);
				break;
			case('b'):

				cube.FillRect(chr_clr, cX+0, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+3, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+4, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+3, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+4, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+9, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+9, cY+9, 1, 1);

				break;

			case('c'):
				cube.FillRect(chr_clr, cX+0, cY+3, 1, 1);
				cube.FillRect(chr_clr, cX+0, cY+4, 1, 1);
				cube.FillRect(chr_clr, cX+0, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+3, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+4, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+3, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+4, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+6, 1, 1);

				break;
			case('d'):

				cube.FillRect(chr_clr, cX+0, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+0, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+0, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+2, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+3, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+4, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+5, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+6, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+3, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+4, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+7, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+0, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+1, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+2, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+3, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+4, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+6, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+8, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+9, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+10, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+11, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+12, 1, 1);
				cube.FillRect(chr_clr, cX+8, cY+13, 1, 1);
				cube.FillRect(chr_clr, cX+9, cY+12, 1, 1);

				break;
			case('e'):

				break;
			case('f'):

				break;
			case('g'):

				break;
			case('h'):

				break;
			case('i'):

				break;
			case('j'):

				break;
			case('k'):

				break;
			case('l'):

				break;
			case('m'):

				break;
			case('n'):

				break;
			case('o'):

				break;
			case('p'):

				break;
			case('q'):

				break;
			case('r'):

				break;
			case('s'):

				break;
			case('t'):

				break;
			case('u'):

				break;
			case('v'):

				break;
			case('w'):

				break;
			case('x'):

				break;
			case('y'):

				break;
			case('z'):

				break;


			case('1'):


				break;

			case('2'):


				break;

			case('3'):

				break;

			}




		


		}

	}
}

