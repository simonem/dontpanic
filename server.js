/*  Variables and import
    
    Imports the express package and creates a server.
    Imports the game engine that handles all game logic.
    Imports http and makes a server that socket.io can listen to.
*/
var http		= require('http'),
	express     = require('express'),
    server      = module.exports = express(),
    engine      = require('./server/js/engine.js'),
    ioserver    = require('http').createServer(server),
    games       = {},
    uuid        = require('node-uuid'),
    db			= require('./database.js');
	net			= require('net');

 /* Configuration of express server:

Makes the ejs module handle all html files.
Sets port to 8008.
Directs all view-requests to the views folder.
All static files are served from the rec folder
*/

server.engine('.html', require('ejs').__express);
server.set('views', __dirname + '/client/views');
server.use(express.static(__dirname + '/client/rec'));
server.use('/img', (__dirname + '/client/rec/img'));
server.use('/music', (__dirname + '/client/rec/music'));
server.set('view engine', 'html');
server.set('port', process.env.PORT || 8008);

//The main server running the game client
console.log('View server running at http://127.0.0.1:8008/');


/*  Handle http requests	*/

server.get('/', function(request, response){
    response.render('index');
});

server.get('/expert', function(request, response){
    response.render('expert_form');
});

server.get('/replay', function (request, response){
	response.render('replay');
});

server.get('/login', function(request, response){
    console.log("Request for '/login'");
    response.render('login');
});

server.get('/game/', function(request, response){
	var id = request.params.id;
	console.log("Chose game template "+id);
    response.render('game');
});
server.get('/gm', function(request, response){
    console.log("Request for '/gm'");
    response.render('game');
});

/*	Data server

	Used with AJAX to retrieve, send and modify data in the Database.
	POST messages are templates sent from the expert interface, while GET
	messages are requests from the index page for templates.

*/
http.createServer(function (req, res) {
    console.log('Data request received');
	console.log("method: "+req.method);
    console.log("url: "+req.url);

	if(req.method === "POST"){

		console.log("recieved state or template");

		req.on("data", function(data) {
			var datainfo = JSON.parse(data);


			if(datainfo.type == 'state'){
				console.log("state");
				console.log("replay id: " + datainfo.replay_id);

				console.log("command id: " + datainfo.command_id);

				//db.set_replay(datainfo.replay_id, datainfo.command_id, data.toString());

			}
			if(JSON.parse(data).type == 'template'){
				console.log("template");
				db.set_template_string(data.toString());

			}




		});

		//res.end();

	}

	else if (req.method === "GET") {

		if (req.url.indexOf("replays") !== -1) {
			console.log("requesting replays");

			res.writeHead(200, {'Content-Type': 'text/plain'});
			db.get_all_replays(function (result) {
				var	replays = [];
				var temp;
				for (var i = 0; i < result.length;i++){
					temp = result[i];
					replays.push(JSON.stringify(temp));
				}	
				console.log("Sending list of replays");
				res.end('replays('+JSON.stringify(replays)+')');
			});
		}

		else if (req.url.indexOf("show_replay") !== -1) {
			console.log("requesting replay");
			res.writeHead(200, {'Content-Type': 'text/plain'});
			var first_index_of_replay_id = req.url.indexOf("replay_id") + 10;
			var last_index_of_replay_id = req.url.lastIndexOf("&_");			
			var replay_id = req.url.slice(first_index_of_replay_id, last_index_of_replay_id);
			db.get_replay(replay_id, function (result) {
				var replay = [];
				var temp;
				for (var i = 0; i < result.length; i++) {
					temp = result[i];
					replay.push(JSON.parse(temp.state));
				}
				console.log("Sending replay states");
				res.end('start_replay('+JSON.stringify(replay)+')');
			});


		}
		else if (req.url.indexOf("game_master") !== -1) {
			res.writeHead(200, {'Content-Type': 'text/plain'});

			var game_list = [];
			for (var g in games){
				game_list.push(JSON.stringify({id:games[g].id}));
			}
			res.end('game_master('+JSON.stringify(game_list)+')');
		}
		else if (req.url.indexOf("templates") !== -1) {

			res.writeHead(200, {'Content-Type': 'text/plain'});
			db.get_all_templates(function(result) {

				var	gametemplates = [];
				var temp;
				for (var i = 0; i < result.length;i++){
					temp = result[i];
					gametemplates.push(JSON.stringify(temp));
				}

				console.log("Sending list of templates");

				res.end('templates('+JSON.stringify(gametemplates)+')');

			});
		}
	}


}).listen(8124);
console.log('Data server running at http://127.0.0.1:8124/');


/* Configure Socket.IO:
    
    The socket.IO server listens to a http-server, that in turn listens to the express server.
*/
ioserver.listen(server.get('port'));
var socket_listener = require('socket.io').listen(ioserver, {log:false});


/*  Handle client interaction through socket.io:

    Listens for commands and sends them to the game engine.
*/   
socket_listener.sockets.on('connection', function (client) {

    client.userid = uuid.v1();
    console.log("Set client ID to "+client.userid);
    client.emit('is_connected');
    console.log('**SOCKET_LISTENER** client ' + client.userid + ' connected');
    
    client.on('dp_user_id', function(o) {
        console.log("Checking for user ID... "+o.id);
        
        if(o.is_gm){
        	client.is_gm = true;
        	client.emit("get_room_id");
        }
        
        else if (o.id !== undefined && o.id !== null && o.id !== "undefined") {
            console.log("Found client with ID "+o.id);
            client.userid = o.id;
            var game = find_game(client.userid);
            if (game) {
            	client.game_id = game;
                games[game].join_game(client);
            }
            else{
            	console.log("Client was not in game");
                client.emit('not_in_game', {userid:client.userid});
            }
        }
        else{
        	console.log("Client was not in game");
            client.emit('not_in_game', {userid:client.userid});
       }
    });
    
    //Client sent log message
    client.on('msg', function(msg) {
        console.log('**SOCKET_LISTENER** received message: '+ msg);
    });
    

    client.on('end_game', function(c) {
        console.log('**SOCKET_LISTENER** received command ' + c);
        engine.end_game(client, c);
    });

	//Client has chosen a game template, and sent a template_id to start a game with.
    client.on('create_game', function(c) {

		console.log('**SOCKET_LISTENER** received create command ');

    	console.log('Retrieving template with id: '+c.template_id);
    	db.get_template_string(c.template_id, function(result) {
			var	gametemplate = JSON.parse(result[0].json_string);

			console.log("Creating game object based on template..");

			db.get_replay_id(function (result) { 
				var g = new engine(client.userid, client, gametemplate, c.template_id, result+1);
				console.log("Created.");
				console.log(typeof g);
	    		games[g.id] = g;
	    		client.game_id = g.id;
	    		g.start(client);	

			});
		});
    })
    
    client.on('selected_room_id', function(room){
    	 games[room].join_game(client);
    });

    client.on('join_game', function(c) {
        console.log('**SOCKET_LISTENER** received join command ' + c);
        engine.join_game(client, c);
    });
    
    client.on('leave_game', function(c) {
        console.log('**SOCKET_LISTENER** received leave command ' + c);
        //TODO Save game replay
        games[client.game_id].delete_game();
        delete games[client.game_id];
    });
    
    client.on('game_command', function(c) {
        console.log('');
        console.log('**SOCKET_LISTENER** Received:');
        var parsed = JSON.parse(c);
        
        if(client.game_id){
        	var g = games[client.game_id];
		    g.command(client, parsed);
		    //db.set_replay(g.replay_id, g.state_id, JSON.stringify(g.state()));
		}
    });

	client.on('replay', function (c) {
		db.get_all_replays(function(result) {

			var r = new replay(result);
			var	replays = [];
			var temp;

			for (var i = 0; i < result.length;i++){
				temp = result[i];
				replays.push(JSON.stringify(temp));
			}
			res.end('replays('+JSON.stringify(replays)+')');
		});
	})

    client.on('disconnect', function () {
        console.log('**SOCKET_LISTENER** client ' + client.userid + ' disconnected.');
       	//TODO Save to DB
        //TODO close game
    });

});// end onConnection


/**
* Finds an existing game by searching through 
* the client ids of active games.
*
* @method find_game
* @param {String} userid Id of the user to seach for
*/
function find_game(userid){
	for(var g in games){
		console.log("Checking game.. "+games[g].id);
		if(games[g].has_client(userid)) return games[g].id;
	}
	return;
}
var HOST = '127.0.0.1';
var PORT = 6969;

// Create a server instance, and chain the listen function to it
// The function passed to net.createServer() becomes the event handler for the 'connection' event
// The sock object the callback function receives UNIQUE for each connection
net.createServer(function(sock) {
    
    // We have a connection - a socket object is assigned to the connection automatically
    console.log('CONNECTED: ' + sock.remoteAddress +':'+ sock.remotePort);
    
    // Add a 'data' event handler to this instance of socket
    sock.on('data', function(data) {
        
        console.log('DATA ' + sock.remoteAddress + ': ' + data);
		
        
		var data2;
		
		for(var g in games){
			
			
			data2 = games[g].getInfo(data);
			
			console.log(data2);
			
			sock.write(data2 + '\n');
			
			break;
		}
		
		
        
    });
    
    // Add a 'close' event handler to this instance of socket
    sock.on('close', function(data) {
        console.log('CLOSED: ' + sock.remoteAddress +' '+ sock.remotePort);
    });
    
}).listen(PORT, HOST);

console.log('Server listening on ' + HOST +':'+ PORT);

