// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcClient;
using System.Linq;

Console.WriteLine("Hello, World!");
using (var channel = GrpcChannel.ForAddress("https://localhost:7269"))
{
    var client = new Beers.BeersClient(channel);
    var reply = await client.SayHelloAsync(new HelloRequest
    {
        Name = "Mike"
    });

    var reply2 = await client.GetAsync(new BeersRequest());

    reply2.Beers.ToList().ForEach(x => Console.WriteLine(x));
    Console.WriteLine(reply.Message);
    Console.ReadKey();
}
