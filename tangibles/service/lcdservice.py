from Adafruit_CharLCD import Adafruit_CharLCD
from subprocess import * 
from time import sleep
from datetime import datetime

lcd = Adafruit_CharLCD()

lcd.begin(16,4)

def updateLCD(player,turn,apleft,panic):
	lcd.clear()
	lcd.setCursor(0,0)
	lcd.message("Player: "+panic)
	lcd.setCursor(0,1)
	lcd.message("Turn: "+turn)
	lcd.setCursor(0,2)
	lcd.message("Actions left: "+apleft)
	lcd.setCursor(0,3)
	lcd.message("Panic in: "+panic)

while 1:
	updateLCD("simone",1,4,60)
	sleep(2)