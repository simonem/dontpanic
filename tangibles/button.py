import RPi.GPIO as GPIO
from time import sleep


class RPiButton:

    def __init__(self, fun):
        global function
        function = fun
        GPIO.setmode(GPIO.BCM)
        GPIO.setup(18, GPIO.IN, pull_up_down=GPIO.PUD_UP)
	GPIO.add_event_detect(18, GPIO.BOTH, callback=self.get_button_pressed, bouncetime=300)

    def get_button_pressed(self, channel):
		global function
		print 'pressed'
		function()
		#while True:
		#	inputValue = GPIO.input(24)
		#	if(inputValue == True):
		#		print 'The button is pressed'
		#		sleep(.3)
		#	sleep(.01)

    
