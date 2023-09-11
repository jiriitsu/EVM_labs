using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Net.Mail;

struct Message
{
    public bool Result {get;set;}
    public int Data {get;set;}
}
class PipeClient
{
    static void Main(string[] args)
    {
        Message message = new Message();
        message.Data = 10;
        message.Result = false;
    
        using (var newClient = new NamedPipeClientStream("Pipe_lab1"))
        {
            byte[] bytes= new byte[Unsafe.SizeOf<Message>()];
            Console.WriteLine("Client is working...");
            newClient.Connect();
            newClient.Read(bytes);
            message = MemoryMarshal.Read<Message>(bytes);
            message.Result = true;
            MemoryMarshal.Write(bytes, ref message);
            Console.WriteLine("{0}, {1}", message.Result, message.Data);
            newClient.Write(bytes);
            Console.WriteLine("{0}, {1}", message.Result, message.Data);

        }
        Console.WriteLine("Client's work is done");
        Console.ReadLine();
    }
}   