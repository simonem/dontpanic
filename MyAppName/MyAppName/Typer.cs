using System;
using Sifteo;

namespace Dontpanic
{
	public class Typer
	{

		public Typer ()
		{

		}
	
		public void printText(Cube cube, String text, int x, int y){
			int offset = 0;
			foreach(char c in text.ToLower().ToCharArray()){
				offset = offset + printChar(new Color(0,0,0), cube, c, x+offset, y);


			}
		}

		public void printText(Color chr_clr, Cube cube, String text, int x, int y){
			int offset = 0;
			foreach(char c in text.ToLower().ToCharArray()){
				offset = offset + printChar(chr_clr, cube, c, x+offset, y);


			}
		}
		public int getIntLength(string text){
			int length = 0;
			foreach(char c in text.ToCharArray()){
				length += getNumberLength(c);
			}
			return length;
		}


		public int getNumberLength(Char c){
			switch (c){

			case '0':

			return 9;

			case '1':


			return 3;

			case '2':

			return 9;

			case '3':

			return 7;

			case '4':

			return 9;
			case '5':

			return 9;
			case '6':



			return 9;
			case '7':



			return 7;
			case '8':


			return 9;
			case '9':

			return 9;

			}
		return 30;
		}

		// draws a char to on the cube 
		// returns an int to tell how wide the char is
		public int printChar( Color chr_clr, Cube cube, char d, int cX, int cY){


			switch (d) {
			case 'a':

				cube.FillRect (chr_clr, cX + 1, cY + 4, 2, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 3);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 3);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 4, 1);

		
				return 6;
			case 'b':

				cube.FillRect (chr_clr, cX + 0, cY + 1, 1, 7);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 2, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 3);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 2, 1);
			
				return 5;

			case 'c':

				cube.FillRect (chr_clr, cX + 0, cY + 0, 5, 30);
				cube.FillRect (chr_clr, cX + 5, cY + 0, 20, 5);
				cube.FillRect (chr_clr, cX + 5, cY + 25, 20, 5);
	
				return 26;
			case 'd':

				cube.FillRect (chr_clr, cX + 0, cY + 0, 5, 30);
				cube.FillRect (chr_clr, cX + 5, cY + 0, 12, 5);
				cube.FillRect (chr_clr, cX + 5, cY + 25, 12, 5);
				cube.FillRect (chr_clr, cX + 15, cY + 2, 5, 5);
				cube.FillRect (chr_clr, cX + 15, cY + 23, 5, 5);
				cube.FillRect (chr_clr, cX + 17, cY + 5, 6, 7);
				cube.FillRect (chr_clr, cX + 17, cY + 18, 6, 7);
				cube.FillRect (chr_clr, cX + 19, cY + 11, 6, 8);


				return 26;
			case 'e':

				cube.FillRect (chr_clr, cX + 0, cY + 0, 5, 30);
				cube.FillRect (chr_clr, cX + 5, cY + 0, 18, 5);

				cube.FillRect (chr_clr, cX + 5, cY + 13, 8, 4);

				cube.FillRect (chr_clr, cX + 5, cY + 25, 18, 5);
			

	
	
				return 24;
			case 'f':

				cube.FillRect (chr_clr, cX + 0, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 9, 1, 1);

				cube.FillRect (chr_clr, cX + 2, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 3, 1, 1);
				return 5;
			case 'g':

				cube.FillRect (chr_clr, cX + 1, cY + 4, 2, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 2);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 5);
				cube.FillRect (chr_clr, cX + 1, cY + 7, 2, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 10, 2, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 4, 1, 2);

				return 6;
			case 'h':

				cube.FillRect (chr_clr, cX + 0, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 1, 1);
		
				cube.FillRect (chr_clr, cX + 5, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 9, 1, 1);

				return 7;
			case 'i':

				cube.FillRect (chr_clr, cX + 0, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 4);
		
				return 2;
			case 'j':


				cube.FillRect (chr_clr, cX + 0, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 1);

				cube.FillRect (chr_clr, cX + 1, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 12, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 13, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 14, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 12, 1, 1);
				return 3;
			case 'k':


				cube.FillRect (chr_clr, cX + 0, cY + 0, 1, 1);

				cube.FillRect (chr_clr, cX + 1, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 11, 1, 1);

				cube.FillRect (chr_clr, cX + 6, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 11, 1, 1);
				return 8;
			case 'l':


				cube.FillRect (chr_clr, cX + 0, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 11, 1, 1);
				return 3;

			case 'm':

				cube.FillRect (chr_clr, cX + 0, cY + 0, 5, 30);
				cube.FillRect (chr_clr, cX + 5, cY + 2, 4, 7);
				cube.FillRect (chr_clr, cX + 9, cY + 5, 4, 7);

				cube.FillRect (chr_clr, cX + 12, cY + 8, 6, 7);

				cube.FillRect (chr_clr, cX + 13, cY + 15, 4, 3);

				cube.FillRect (chr_clr, cX + 17, cY + 5, 4, 7);
				cube.FillRect (chr_clr, cX + 21, cY + 2, 4, 7);
				cube.FillRect (chr_clr, cX + 25, cY + 0, 5, 30);
			
	

				return 31;
			case 'n':

				cube.FillRect (chr_clr, cX + 0, cY + 3, 1, 6);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 2, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 4);
		
				return 5;
			case 'o':


				cube.FillRect (chr_clr, cX + 0, cY + 11, 6, 8);
				cube.FillRect (chr_clr, cX + 2, cY + 5, 6, 7);
				cube.FillRect (chr_clr, cX + 2, cY + 18, 6, 7);
				cube.FillRect (chr_clr, cX + 5, cY + 2, 5, 5);
				cube.FillRect (chr_clr, cX + 5, cY + 23, 5, 5);
				cube.FillRect (chr_clr, cX + 8, cY + 0, 9, 5);
				cube.FillRect (chr_clr, cX + 8, cY + 25, 9, 5);
				cube.FillRect (chr_clr, cX + 15, cY + 2, 5, 5);
				cube.FillRect (chr_clr, cX + 15, cY + 23, 5, 5);
				cube.FillRect (chr_clr, cX + 17, cY + 5, 6, 7);
				cube.FillRect (chr_clr, cX + 17, cY + 18, 6, 7);
				cube.FillRect (chr_clr, cX + 19, cY + 11, 6, 8);

				

		
				return 26;
			case 'p':

				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 6);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 2, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 3);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 2, 1);
	
		
				return 5;
			case 'q':


				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 3);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 2, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 6);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 2, 1);
			
		
	
				return 5;
			case 'r':


				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 5);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 5, 1, 1);
			
				return 4;
			case 's':


				cube.FillRect(chr_clr, cX+1, cY+4, 2, 1);
				cube.FillRect(chr_clr, cX+0, cY+5, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+6, 2, 1);
				cube.FillRect(chr_clr, cX+3, cY+7, 1, 1);
				cube.FillRect(chr_clr, cX+1, cY+8, 2, 1);
			
				return 5;
			case 't':

				cube.FillRect (chr_clr, cX + 1, cY + 4, 1, 5);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 3, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 8, 1, 1);
				return 4;
			case 'u':
			

				cube.FillRect (chr_clr, cX + 0, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 6, 1, 1);
			
				return 7;
			case 'v':


				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 4);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 4);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 1, 1);
	
				return 4;
			case 'w':
				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 4);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 4);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 4, 1, 4);
				cube.FillRect (chr_clr, cX + 3, cY + 8, 1, 1);

				return 6;
			case 'x':


				cube.FillRect (chr_clr, cX + 0, cY + 4, 1, 2);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 2);
				cube.FillRect (chr_clr, cX + 1, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 7, 1, 2);
				cube.FillRect (chr_clr, cX + 2, cY + 7, 1, 2);
	
				return 4;
			case 'y':

				cube.FillRect (chr_clr, cX + 0, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 10, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 11, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 9, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 10, 1, 1);
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
				cube.FillRect (chr_clr, cX + 7, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 8, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 8, cY + 1, 1, 1);
				return 9;
			case 'z':


				cube.FillRect (chr_clr, cX + 0, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 0, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 1, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 7, 1, 1);
				cube.FillRect (chr_clr, cX + 2, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 5, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 6, 1, 1);
				cube.FillRect (chr_clr, cX + 3, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 4, 1, 1);
				cube.FillRect (chr_clr, cX + 4, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 3, 1, 1);
				cube.FillRect (chr_clr, cX + 5, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 1, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 2, 1, 1);
				cube.FillRect (chr_clr, cX + 6, cY + 8, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 0, 1, 1);
				cube.FillRect (chr_clr, cX + 7, cY + 8, 1, 1);
				return 8;

			case '0':
				cube.FillRect (chr_clr, cX + 0, cY + 2, 2, 4); // 1
				cube.FillRect (chr_clr, cX + 0, cY + 8, 2, 4); // 2
				cube.FillRect (chr_clr, cX + 2, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 2, cY + 12, 4, 2); // 5
				cube.FillRect (chr_clr, cX + 6, cY + 2, 2, 4); // 6
				cube.FillRect (chr_clr, cX + 6, cY + 8, 2, 4); // 7

				return 9;

			case '1':
				cube.FillRect (chr_clr, cX + 0, cY + 2, 2, 4); // 1
				cube.FillRect (chr_clr, cX + 0, cY + 8, 2, 4); // 2

				return 3;

			case '2':


				cube.FillRect (chr_clr, cX + 0, cY + 8, 2, 4); // 2
				cube.FillRect (chr_clr, cX + 2, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 2, cY + 6, 4, 2); // 4 
				cube.FillRect (chr_clr, cX + 2, cY + 12, 4, 2); // 5
				cube.FillRect (chr_clr, cX + 6, cY + 2, 2, 4); // 6
			
				return 9;

			case '3':
			


				cube.FillRect (chr_clr, cX + 0, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 0, cY + 6, 4, 2); // 4 
				cube.FillRect (chr_clr, cX + 0, cY + 12, 4, 2); // 5
				cube.FillRect (chr_clr, cX + 4, cY + 2, 2, 4); // 6
				cube.FillRect (chr_clr, cX + 4, cY + 8, 2, 4); // 7

				return 7;

			case '4':

				cube.FillRect (chr_clr, cX + 0, cY + 2, 2, 4); // 1
				cube.FillRect (chr_clr, cX + 2, cY + 6, 4, 2); // 4 
				cube.FillRect (chr_clr, cX + 6, cY + 2, 2, 4); // 6
				cube.FillRect (chr_clr, cX + 6, cY + 8, 2, 4); // 7

				return 9;
			case '5':

				cube.FillRect (chr_clr, cX + 0, cY + 2, 2, 4); // 1
				cube.FillRect (chr_clr, cX + 2, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 2, cY + 6, 4, 2); // 4 
				cube.FillRect (chr_clr, cX + 2, cY + 12, 4, 2); // 5
				cube.FillRect (chr_clr, cX + 6, cY + 8, 2, 4); // 7
				return 9;
			case '6':

				cube.FillRect (chr_clr, cX + 0, cY + 2, 2, 4); // 1
				cube.FillRect (chr_clr, cX + 0, cY + 8, 2, 4); // 2
				cube.FillRect (chr_clr, cX + 2, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 2, cY + 6, 4, 2); // 4 
				cube.FillRect (chr_clr, cX + 2, cY + 12, 4, 2); // 5
				cube.FillRect (chr_clr, cX + 6, cY + 8, 2, 4); // 7

				return 9;
			case '7':

				cube.FillRect (chr_clr, cX + 0, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 4, cY + 2, 2, 4); // 6
				cube.FillRect (chr_clr, cX + 4, cY + 8, 2, 4); // 7
		
				return 7;
			case '8':

				cube.FillRect (chr_clr, cX + 0, cY + 2, 2, 4); // 1
				cube.FillRect (chr_clr, cX + 0, cY + 8, 2, 4); // 2
				cube.FillRect (chr_clr, cX + 2, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 2, cY + 6, 4, 2); // 4 
				cube.FillRect (chr_clr, cX + 2, cY + 12, 4, 2); // 5
				cube.FillRect (chr_clr, cX + 6, cY + 2, 2, 4); // 6
				cube.FillRect (chr_clr, cX + 6, cY + 8, 2, 4); // 7

				return 9;
			case '9':

				cube.FillRect (chr_clr, cX + 0, cY + 2, 2, 4); // 1
				cube.FillRect (chr_clr, cX + 2, cY + 0, 4, 2); // 3
				cube.FillRect (chr_clr, cX + 2, cY + 6, 4, 2); // 4 
				cube.FillRect (chr_clr, cX + 2, cY + 12, 4, 2); // 5
				cube.FillRect (chr_clr, cX + 6, cY + 2, 2, 4); // 6
				cube.FillRect (chr_clr, cX + 6, cY + 8, 2, 4); // 7

				return 9;

			case '-':

				cube.FillRect (chr_clr, cX + 2, cY + 6, 4, 2); // 4 

				return 5;
			
			}

			return 5;
		


		}

	}
}

