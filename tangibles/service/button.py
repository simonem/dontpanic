import RPi.GPIO as GPIO
from time import sleep
import os

class RPiButton:

    def __init__(self, next_turn, use_card, remove_action):
        global next_turn_function
	global use_card_function
	global remove_action_function
	global p
	remove_action_function = remove_action
        next_turn_function = next_turn
	use_card_function = use_card
	global isNotReading
	isNotReading = True
	p=os.popen('/usr/bin/zbarcam --raw --nodisplay -Sdisable -Scode39.enable /dev/video0','r')

        GPIO.setmode(GPIO.BCM)
        GPIO.setup(18, GPIO.IN, pull_up_down=GPIO.PUD_UP)
	GPIO.setup(4, GPIO.IN, pull_up_down=GPIO.PUD_UP)
	GPIO.add_event_detect(18, GPIO.BOTH, callback=self.get_button_pressed, bouncetime=5000)
	GPIO.add_event_detect(4, GPIO.FALLING, callback=self.start_read_barcode, bouncetime=5000)

    def get_button_pressed(self, channel):
		global next_turn_function
		print 'pressed'
		next_turn_function()

    def start_read_barcode(self, channel):
		global isNotReading
		global use_card_function
		global remove_action_function
		global blist
		global p
		if(isNotReading):
			isNotReading = False

			print 'looking for barcode key was pressed'
			code = p.readline()
			#p.close()
			if code:
				print 'got barcode:', code
				isNotReading = True
				if(code == 'BLOCK\n'):
					os.system('mpg321 /home/pi/dontpanic/tangibles/service/success.mp3 &')
					remove_action_function()
				else:
					for i in range(len(blist)):
						if(blist[i] == int(code)):
							os.system('mpg321 /home/pi/dontpanic/tangibles/service/success.mp3 &')
							use_card_function(i)
    def updateList(self, list):
	global blist
	blist = list
