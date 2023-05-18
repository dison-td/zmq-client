

using NetMQ;
using NetMQ.Sockets;
string GetRandomString()
    {
        string path = Path.GetRandomFileName();
        path = path.Replace(".", ""); // Remove period.
        return path;
    }

using (var client = new RequestSocket())
{
    client.Connect("tcp://127.0.0.1:5556");
    var count = 0;
    while (true) 
    {
        client.SendFrame(String.Format("{0} {1}", GetRandomString(),  count++));
        var msg = client.ReceiveFrameString();
        Console.WriteLine(msg);
   //  System.Threading.Thread.Sleep(5);
    }
}
