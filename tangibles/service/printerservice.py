#!/usr/bin/python

from Adafruit_Thermal import *

class Printer:
	def __init__(self):
		global printer
		printer = Adafruit_Thermal("/dev/ttyAMA0", 19200, timeout=5)
		
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
		printer.println(event['desc'])
		printer.feed(3)

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
		printer.feed(3)
#printer.justify('C')
#printer.setSize('L')
#printer.println("Don't Panic!")
#printer.feed(3)
