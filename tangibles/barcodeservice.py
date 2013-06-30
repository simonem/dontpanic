import os


class BarcodeReader:
	def __init__(self):
		global p
		#global function
		#function = fun
		p=os.popen('/usr/bin/zbarcam --raw --nodisplay -Sdisable -Scode39.enable /dev/video0','r')

	def read_barcode(self, fun):
		print 'trying to read'
		print p
		code = p.readline()
		print 'gonna try again'

		if code:
			print 'Got barcode:', code
			fun(code)
			
#while True:
#	code = p.readline()
#	if code:
#		print 'Got barcode:', code
    
