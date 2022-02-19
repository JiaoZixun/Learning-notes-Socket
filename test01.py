from Client import *
import time

# 初始化构造一个客户端
client = Client()
#模拟算法进行
for i in range(0,10):
    msg = str(i)            #！！！！！发送的必须为string类型
    client._send(msg) #每次用客户端发送一个数
    time.sleep(1)   #如果发送太快，多条语句就会合并为一条发送
client._close()

