using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


struct Message
{
    public bool Result{get;set;}
    public int Data {get;set;}
}

class PipeClient
{
    

    static void Main(string[] args)
    {
        Message message = new Message();
        message.Data = 10;
        message.Result = false;
        using (var newServer = new NamedPipeServerStream("Pipe_lab1"))
        {
                        
            Console.WriteLine("Server is working...");
            
            //struct to byte
            byte[] bytes= new byte[Unsafe.SizeOf<Message>()];
            MemoryMarshal.Write(bytes, ref message);
            Console.WriteLine("{0}, {1}", message.Data, message.Result);  
            newServer.WaitForConnection();
            newServer.Write(bytes);
            newServer.Read(bytes);
            message = MemoryMarshal.Read<Message>(bytes);
            Console.WriteLine("{0}", message.Result);

            
        }
        Console.WriteLine("Server's work is done");
        Console.ReadLine();
    }
}