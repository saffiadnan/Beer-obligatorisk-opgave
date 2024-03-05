from socket import *

def get_user_input(command):
    num1 = input("Indtast første nummer: ")
    num2 = input("Indtast andet nummer: ")
    return f"{command} {num1} {num2}"

def menu():
    print("\nVælg en af kommando:")
    print("1. Random")
    print("2. Add")
    print("3. Subtract")
    print("4. Exit")
    return input("Vælg tal mellem 1 til 4): ")

serverName = "localhost"
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

while True:
    user_choice = menu()

    if user_choice == '4':
        print("Lukker klienten...")
        break
    elif user_choice in ['1', '2', '3']:
        sentence = get_user_input(user_choice)
        clientSocket.send(sentence.encode())
        modifiedSentence = clientSocket.recv(1024)
        print('From server:', modifiedSentence.decode())
    else:
        print("Forkert valg. Vælg tal mellem 1 til 4.")

clientSocket.close()