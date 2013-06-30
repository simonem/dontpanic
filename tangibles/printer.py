from service.Adafruit_Thermal import *


class Printer:
	
	def __init__(self):
		global printer
		printer = service.Adafuit_Thermal("/dev/ttyAMA0", 19200, timeout=5)
		

	def print_event(self, event):
		global printer
		#event is eventname only for test
		printer.justify('C')
		printer.println(event)
