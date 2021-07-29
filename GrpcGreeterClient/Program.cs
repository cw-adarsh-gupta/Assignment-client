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
           
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Num1=30, Num2=10 });
            Console.WriteLine("Answer "+reply.Result);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}