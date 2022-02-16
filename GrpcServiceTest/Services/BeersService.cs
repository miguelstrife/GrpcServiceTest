using Grpc.Core;
using GrpcServiceTest;

namespace GrpcServiceTest.Services
{
    public class BeersService : Beers.BeersBase
    {
        private readonly ILogger<BeersService> _logger;
        public BeersService(ILogger<BeersService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<BeersReply> Get(BeersRequest request, ServerCallContext context)
        {
            var reply = new BeersReply();
            reply.Beers.AddRange(new List<string>
            {
                "London Pride", "Erdinger", "Kapuziner"
            });

            return Task.FromResult(reply);
        }
    }
}