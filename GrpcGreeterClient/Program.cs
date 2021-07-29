using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
           Console.WriteLine("Enter number1 ");
           int num1 = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("Enter number2 ");
           int num2 = Convert.ToInt32(Console.ReadLine());
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Num1=num1, Num2=num2 });
            Console.WriteLine("Answer "+reply.Result);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}