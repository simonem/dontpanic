#!/usr/bin/python

from Adafruit_Thermal import *

printer = Adafruit_Thermal("/dev/ttyAMA0", 19200, timeout=5)

printer.justify('C')
printer.setSize('L')
printer.println("Don't Panic!")
printer.feed(3)