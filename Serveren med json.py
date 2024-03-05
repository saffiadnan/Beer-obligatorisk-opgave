from socket import *
import json
import random

def process_command(request):
    try:
        data = json.loads(request)
        command = data['method']
        num1 = data['Tal1']
        num2 = data['Tal2']
        
        if command == "random":
            result = random.randint(min(num1, num2), max(num1, num2))
            response = {"status": "success", "message": f"Det tilfældige tal mellem {num1} og {num2} er: {result}"}
        elif command == "add":
            result = num1 + num2
            response = {"status": "success", "message": f"Resultatet af {num1} + {num2} er: {result}"}
        elif command == "subtract":
            result = num1 - num2
            response = {"status": "success", "message": f"Resultatet af {num1} - {num2} er: {result}"}
        else:
            response = {"status": "error", "message": "Ukendt kommando"}
    except (json.JSONDecodeError, KeyError):
        response = {"status": "error", "message": "Ugyldig JSON-forespørgsel"}
    
    return json.dumps(response)

serverPort = 12000
serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(('', serverPort))
serverSocket.listen(1)
print('Serveren er klar')

while True:
    connectionSocket, addr = serverSocket.accept()
    print(f"Forbindelse fra {addr} accepteret")
    
    try:
        sentence = connectionSocket.recv(1024).decode()
        if not sentence or sentence.lower() == "exit":
            print("Forbindelse lukket")
        else:
            response = process_command(sentence)
            connectionSocket.send(response.encode())
    finally:
        connectionSocket.close()
