using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System.Data;
using Microsoft.VisualBasic;


// Добавление данных для отправки в очередь должно происходить до тех пор
// пока не будет нажата комбинация клавиш Ctrl+C. Также при добавлении данных в очередь должен учитываться приоритет отправляемых данных. 
// Полученные обратно от второго консольного приложения (клиент) данные должны сохраняться в буфер, 
// который будет записываться в файл или выводиться на экран после нажатия комбинации клавиш Ctrl+C.
struct Message
{
    public string MyString {get;set;}
    public int Priority {get;set;}
}

class PipeServer
{
    private static PriorityQueue<Message,int> myQueue = new();

    static void Main(string[] args)
    {
        //Message
        Message message = new Message();
        
        //Init data

        Console.WriteLine("Enter the priority of value");       

        if(int.TryParse(Console.ReadLine(), out int priority)){           
            myQueue.Enqueue(message, priority);
        }
        else
        {
            myQueue.Enqueue(message,0);
        }


        
        using (var newServer = new NamedPipeClientStream("Pipe_lab2"))
        {
            // byte[] bytes= new byte[Unsafe.SizeOf<Message>()];
            // Console.WriteLine("Client is working...");
            // newClient.Connect();
            // newClient.Read(bytes);
            // message = MemoryMarshal.Read<Message>(bytes);
            // message.Result = true;
            // MemoryMarshal.Write(bytes, ref message);
            // Console.WriteLine("{0}, {1}", message.Result, message.Data);
            // newClient.Write(bytes);
            // Console.WriteLine("{0}, {1}", message.Result, message.Data);

        }
        Console.WriteLine("Client's work is done");
        Console.ReadLine();
    }
}   