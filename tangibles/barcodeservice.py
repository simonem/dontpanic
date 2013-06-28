import os

p=os.popen('/usr/bin/zbarcam --raw --nodisplay -Sdisable -Scode39.enable /dev/video0','r')

while True:
	code = p.readline()
	if code:
		print 'Got barcode:', code
    