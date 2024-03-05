from socket import *
import json  

def get_user_input(command):
    num1 = input("Indtast første tal: ")
    num2 = input("Indtast andet tal: ")
    return json.dumps({"method": command, "Tal1": int(num1), "Tal2": int(num2)})

def menu():
    print("\nVælg en af kommando:")
    print("1. Random")
    print("2. Add")
    print("3. Subtract")
    print("4. Exit")
    user_choice = input("Vælg tal mellem 1 til 4): ")

    commands = {"1": "random", "2": "add", "3": "subtract"}
    return commands.get(user_choice, "exit"), user_choice

serverName = "localhost"
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

while True:
    command, user_choice = menu()
    
    if user_choice == '4':
        print("Lukker klienten...")
        break  
    elif command in ['random', 'add', 'subtract']:
        json_request = get_user_input(command)
        clientSocket.send(json_request.encode())
        modifiedSentence = clientSocket.recv(1024)
        print('From server:', modifiedSentence.decode())
    else:
        print("Forkert valg. Vælg tal fra 1 til 4.")

clientSocket.close()