from Adafruit_CharLCD import Adafruit_CharLCD
from subprocess import * 
from time import sleep
from datetime import datetime

class LcdService:
	
	def __init__(self):
		global lcd
		global gamerunning
		gamerunning = True
		lcd = Adafruit_CharLCD()
		lcd.begin(16,4)
	
	def updateLCD(self,player,turn,apleft,panic):
		global lcd
		global gamerunning
		if(gamerunning):
			lcd.clear()
			lcd.setCursor(0,0)
			lcd.message("Player: "+str(player))
			lcd.setCursor(0,1)
			lcd.message("Turn: "+str(turn))
			lcd.setCursor(0,2)
			lcd.message("Actions left: "+str(apleft))
			lcd.setCursor(0,3)
			lcd.message("Panic in: "+str(panic))

	def game_is_lost(self):
		global lcd
		global gamerunning
		gamerunning = False
		lcd.setCursor(0,0)
		lcd.message("Game is Lost!")

	def game_is_won(self):
		global lcd
		global gamerunning
		gamerunning = False
		lcd.setCursor(0,0)
		lcd.message("Game is Won!")
