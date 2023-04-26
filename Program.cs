

using NetMQ;
using NetMQ.Sockets;

using (var client = new RequestSocket())
{
    client.Connect("tcp://127.0.0.1:5556");
    var count = 0;
    while (true) 
    {
        client.SendFrame(String.Format("Hello {0}", count++));
        var msg = client.ReceiveFrameString();
        Console.WriteLine("From Server: {0}", msg);
    }
}
