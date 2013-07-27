from socketIO_client import SocketIO
from service.button import RPiButton
try: import simplejson as json
except: import json
from service.lcdservice import LcdService
from service.printerservice import Printer
global socketIO

# Insert DP server address
socketIO = SocketIO('dp-server.local', 8008)

global game_template
game_template = {}

def starting_game(template):
	# Hw initialization
	# Printer
	global printed
	printed = []
	global printer
	printer = Printer()
	# LCD
	global lcdscreen
	lcdscreen = LcdService()
	# Buttons and LEDs
	global button
	button = RPiButton(call_next_turn, use_this_card, remove_action)

	global game_template		
	game_template = json.loads(template)
	
	for player in game_template['players']:
		printer.print_playercard((player['id'] + 1), player['role'])
	
	activeplayer = game_template['players'][game_template['active_player']]
	for i in range(len(activeplayer['cardsid'])):
		printer.print_infocard(activeplayer['info_cards'][i], activeplayer['cardsid'][i], (activeplayer['id']+1))
		printed.append(activeplayer['cardsid'][i])
	button.updateList(activeplayer['cardsid'])
	global timer
	timer = 0
	return None
    
def get_active_player():
    global game_template
    if(game_template.has_key('active_player')):
        theactiveplayer = game_template['active_player']
        return theactiveplayer
    return 'no active player was found'

def get_cards_from_player(playerid):
    global game_template
    if(len(game_template['players']) > playerid ):
        cards = game_template['players'][playerid]['info_cards']
        return cards
    return {}


def get_cardinfo(cardid):
    print get_cards_from_player(get_active_player())[cardid]['desc']
        
        
def get_actions_left():
    return game_template['players'][get_active_player()]['actions_left']
       
def print_lcd_info(self):
	active_player = self.get_active_player()
	turn = game_template['turn']
	actions_left = self.get_actions_left()
	lcd_info = "Player: "
	lcd_info += str(active_player)
	lcd_info += "\nTurn: "
	lcd_info += str(turn)
	lcd_info += "\nAction points left:"
	lcd_info += str(actions_left)
	lcd_info += "\nPanic increase in: "
	lcd_info += str(timer)
	print lcd_info
        
def on_response():
	global socketIO
	print 'DEBUG: connected to the server'
	socketIO.emit('python_join_game') 
	return None


def call_next_turn():
    print 'DEBUG: telling server next turn'
    endturncommand = { 'type':'end_turn'} 
    socketIO.emit('game_command', json.dumps(endturncommand))

def remove_action():
    print 'DEBUG: removing one action'
    gamecommand = {
	"type":"decrease_actions"
    }
    socketIO.emit('game_command', json.dumps(gamecommand))

def use_this_card(cardid):
    print 'DEBUG: using a cardid', cardid
    gamecommand = {
	"type":"use_card",
	"card":cardid
    }
    socketIO.emit('game_command', json.dumps(gamecommand))
    return None

def got_message(msg):        
    print 'DEBUG: server said', msg


def change(arg):
    global timer
    global printed
    global printer
    global lcdscreen
    global button
    global game_template
    changes = json.loads(arg)
    if(changes.has_key('timer')):
        timer = changes['timer']

    if(changes.has_key('turn')):
        if(changes.has_key('active_player')):
            game_template['active_player'] = changes['active_player']
	    game_template['turn'] = changes['turn']
	    if(changes.has_key('players')):
		for player in changes['players']:
			if(player['id'] == game_template['active_player']):
				if(player.has_key('info_cards')):
					for i in range(len(player['cardsid'])):
						if(printed.count(player['cardsid'][i]) < 1):
							printer.print_infocard(player['info_cards'][i], player['cardsid'][i], (player['id']+1))
							printed.append(player['cardsid'][i])
					button.updateList(player['cardsid'])
					
    if(changes.has_key('players')):
        for player in changes['players']:
	    if(player != None):
	    	if(player.has_key('id')):
			for i in range(len(game_template['players'])):
				if(player['id'] == game_template['players'][i]['id']):
					game_template['players'][i] = player
					
    if(changes.has_key('zones')):
        print 'has zones'
            
    if(changes.has_key('nodes')):
        print 'has nodes'

    if(changes.has_key('options')):
        print 'has options'
            
    if(changes.has_key('event')):
        print 'has an event'
	printer.print_event(changes['event'])
            
    if(changes.has_key('win')):
	if(changes['win']):
		print 'game is won'
		lcdscreen.game_is_won()
		
    if(changes.has_key('lose')):         
        if(changes['lose']):
            print 'game is lost'
	    lcdscreen.game_is_lost()
	
    active_player = game_template['active_player']
    turn = game_template['turn']
    actions_left = game_template['players'][active_player]['actions_left']
    lcdscreen.updateLCD(active_player + 1,turn,actions_left,timer)

def got_error(arg):
    print 'got an error here'
    print arg

socketIO.on('is_connected', on_response)
socketIO.on('change', change)
socketIO.on('start_game', starting_game)
socketIO.on('msg', got_message)
socketIO.on('error', got_error)
socketIO.wait(seconds=120000)
