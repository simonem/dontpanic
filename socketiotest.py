from socketIO_client import SocketIO
try: import simplejson as json
except: import json




def get_lcd_info():
    active_player = get_active_player()
    turn = game_template['turn']
    actions_left = get_actions_left()
    lcd_info = "Player: "
    lcd_info += str(active_player)
    lcd_info += "\nTurn: "
    lcd_info += str(turn)
    lcd_info += "\nAction points left:"
    lcd_info += str(actions_left)
    lcd_info += "\nPanic increase in: "
    lcd_info += str(timer)
##    lcd_info = str('Player:', active_player, '\nTurn:', turn, '\nAction points left:', actions_left, '\nPanic increase in:', timer)
    
##    print 'Player:', active_player, '\nTurn:', turn, '\nAction points left:', actions_left, '\nPanic increase in:', timer
    print lcd_info
    

def get_active_player():
    theactiveplayer = game_template['active_player']
    return theactiveplayer

def get_cardinfo(cardid):
    print get_cards_from_player(get_active_player())[cardid]['desc']
    
    
def get_actions_left():
    return game_template['players'][get_active_player()]['actions_left']

def get_cards_from_player(playerid):
    if(len(game_template['players']) > playerid ):
        cards = game_template['players'][playerid]['info_cards']
        return cards


    
def use_this_card(cardid):
    gamecommand = {
        "type":"use_card",
        "card":cardid
        }
    socketIO.emit('game_command', json.dumps(gamecommand))
    


def call_next_turn():
    print 'telling server end turn'
    endturncommand = { 'type':'end_turn'} 
    socketIO.emit('game_command', json.dumps(endturncommand))

    

def got_message(msg):
    
    print 'server said', msg

def on_response():
    print 'connected to the server'
   
##    template_id =  { 'template_id':9} 
##    socketIO.emit('create_game', json.dumps(template_id))
    socketIO.emit('python_join_game')

def change(arg):
    changes = json.loads(arg)
    if(changes.has_key('timer')):

        global timer
        timer = changes['timer']
        print 'timer is', changes['timer']

  
        if(timer == 60):
            get_lcd_info()
            get_cardinfo(0)
            use_this_card(0)

        
        

    if(changes.has_key('turn')):
         print 'has turn'
         if(changes.has_key('active_player')):
             
             game_template['active_player'] = changes['active_player']


    if(changes.has_key('players')):
        print 'has players'

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
    

def starting_game(template):
        
    
    global game_template
    
    game_template = json.loads(template)
    global timer
    timer = 0
    print game_template.keys()


    


socketIO = SocketIO('localhost', 8008)


socketIO.on('is_connected', on_response)

socketIO.on('change', change)

socketIO.on('start_game', starting_game)

socketIO.on('msg', got_message)
