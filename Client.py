from socket import *

class Client:
    tcpCliSock = 0
    def __init__(self):
        HOST = '127.0.0.1'  # or 'localhost'
        PORT = 8500
        BUFSIZ = 1
        ADDR = (HOST, PORT)
        self.tcpCliSock = socket(AF_INET, SOCK_STREAM)
        self.tcpCliSock.connect(ADDR)

    def _send(self, data1):
        self.tcpCliSock.send(data1.encode('utf-8'))

    def _close(self):
        self.tcpCliSock.close()
