#!/usr/bin/python

from Adafruit_Thermal import *

#theprinter = Adafruit_Thermal("/dev/ttyAMA0", 19200, timeout=5)
#theprinter.justify('C')
#theprinter.feed(1)
#theprinter.setBarcodeHeight(200)
#theprinter.printBarcode("block", theprinter.CODE39)
#theprinter.feed(3)

class Printer:
	def __init__(self):
		global printer
		printer = Adafruit_Thermal("/dev/ttyAMA0", 19200, timeout=5)
		#printer.setBarcodeHeigth(200)
		#printer.printBarcode
		
	def print_event(self, event):
		global printer
		printer.justify('C')
		printer.boldOn()
		printer.underlineOn()
		printer.setSize('L')
		printer.println("Event Card")
		printer.boldOff()
		printer.underlineOff()
		printer.feed(1)
		printer.setSize('S')
		printer.println(event['desc'])
		

	def print_infocard(self, infocard, cardid, playerid):
		global printer
		printer.justify('C')
		printer.boldOn()
		printer.underlineOn()
		printer.setSize('L')
		printer.println("Information Card")
		printer.boldOff()
		printer.underlineOff()
		printer.setSize('S')
		printer.println('for player:' + str(playerid))
		printer.feed(1)
		printer.setSize('S')
		printer.println(infocard['desc'])
		printer.feed(3)
		printer.setBarcodeHeight(100)
		printer.printBarcode(str(cardid), printer.CODE39)
		printer.feed(2)

	def print_playercard(self, playerid, playerrole):
		global printer
		printer.justify('C')
		printer.boldOn()
		printer.setSize('L')
		printer.println("Player Card")
		printer.feed(1)
		printer.boldOff()
		printer.setSize('M')
		printer.println("Player " + str(playerid))
		printer.feed(1)
		printer.println(playerrole)
		printer.feed(1)
		printer.setSize('S')
		if(playerrole == "driver"):
			printer.println("The Driver can move 10 people between zones instead of 5")
		if(playerrole == "crowd manager"):
			printer.println("The Crowd manager can decrease panic by 10 instead of 5")
		if(playerrole == "operation expert"):
			printer.println("The Operation Expert can build a roadblock alone")
		printer.feed(2)
		
#printer.justify('C')
#printer.setSize('L')
#printer.println("Don't Panic!")
#printer.feed(3)
