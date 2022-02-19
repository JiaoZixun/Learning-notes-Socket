# socket

c#端为服务端，python端为客户端

*通过127.0.0.1和端口8500连接*

c#关于socket的操作都封装为Server类，提供初始化构建服务端，获取客户端传入信息和关闭服务端函数。

```c#
using ServerManySelf;	//引入Server类的命名空间
Server s = new Server();//创建服务端
//循环保证服务端一直监听客户端信息
string msg = s.GetMessage();//获取客户端传入信息
s.close();	//关闭服务端
```

python关于socket的操作都封装为Client类，提供初始化，发送信息，关闭客户端函数

```python
from Client import *	#引入Client类
client = Client()	# 初始化构造一个客户端
client._send(msg) 	#发送信息，msg必须为string类型
client._close()	#关闭客户端
```

先运行C#的program开启服务端，再运行python的test01开启客户端发送信息。







