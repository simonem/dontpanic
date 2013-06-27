##import RPi.GPIO as GPIO
##from socketIO_client import SocketIO
##try: import simplejson as json
##except: import json
##import time

class RPiButton:

    def __init__(self, fun):
        global function
        function = fun
##        GPIO.setmode(GPIO.BCM)
##        GPIO.setup(24, GPIO.IN)

    def get_button_pressed(self):
        global function
        print 'active player:'
        print str(function())

        
##        print str(tuiclient.get_cardinfo(0))
##        while True:
##            inputValue = GPIO.input(24)
##            if(inputValue == True):
##                print 'The button is pressed'
##                print 'telling server to end turn'
##                endturncommand = { 'type':'end_turn'} 
##                socket.emit('game_command', json.dumps(endturncommand))
##                time.sleep(.3)
##            time.sleep(.01)

    
