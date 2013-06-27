from socketIO_client import SocketIO
from button import RPiButton
try: import simplejson as json
except: import json
from lcdservice import LcdService


global socketIO

socketIO = SocketIO('localhost', 8008)

global game_template
game_template = {}

def starting_game(template):


    global lcdscreen
    lcdscreen = LcdService()
    global button
    button = RPiButton(get_active_player)
    
    global game_template
        
    game_template = json.loads(template)
    
    button.get_button_pressed()
    global timer
    timer = 0
    
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


       
def get_lcd_info(self):
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
    print 'connected to the server'
    socketIO.emit('python_join_game')


def call_next_turn():
    print 'telling server end turn'
    endturncommand = { 'type':'end_turn'} 
    socketIO.emit('game_command', json.dumps(endturncommand))

def use_this_card(cardid):
    gamecommand = {
        "type":"use_card",
        "card":cardid
        }
    socketIO.emit('game_command', json.dumps(gamecommand))
            

def got_message(msg):
        
    print 'server said', msg


def change(arg):
    global timer
    global lcdscreen
    global game_template
    changes = json.loads(arg)
    if(changes.has_key('timer')):

            
        timer = changes['timer']
     
            

    if(changes.has_key('turn')):
        if(changes.has_key('active_player')):
                 
            game_template['active_player'] = changes['active_player']


    if(changes.has_key('players')):

        for player in changes['players']:
                
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
            
        print changes['event']['name'] 
            
    if(changes.has_key('win')):
        if(changes['win']):
            print 'game is won'
           

            
    if(changes.has_key('lose')):
          
        if(changes['lose']):
            print 'game is lost'
    active_player = game_template['active_player']
    turn = game_template['turn']
    actions_left = game_template['players'][active_player]['actions_left']
    lcdscreen.updateLCD(active_player,turn,actions_left,timer)

def got_error(arg):
    print 'got an error here'
    print arg

    
socketIO.on('is_connected', on_response)

socketIO.on('change', change)

socketIO.on('start_game', starting_game)

socketIO.on('msg', got_message)

socketIO.on('error', got_error)


