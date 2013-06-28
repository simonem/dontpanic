from Adafruit_CharLCD import Adafruit_CharLCD
from subprocess import * 
from time import sleep
from datetime import datetime

class LcdService:
	
	def __init__(self):
		print 'placeholder'
		global lcd
		lcd = Adafruit_CharLCD()
		lcd.begin(16,4)
	
	def updateLCD(self,player,turn,apleft,panic):
		print 'placeholderUPDATELCD'
		print 'player: ' + str(player)
		print 'turn: ' + str(turn)
		print 'actions left: ' + str(apleft)
		print 'panic in: ' + str(panic)
		global lcd		
		lcd.clear()
		lcd.setCursor(0,0)
		lcd.message("Player: "+str(player))
		lcd.setCursor(0,1)
		lcd.message("Turn: "+str(turn))
		lcd.setCursor(0,2)
		lcd.message("Actions left: "+str(apleft))
		lcd.setCursor(0,3)
		lcd.message("Panic in: "+str(panic))

