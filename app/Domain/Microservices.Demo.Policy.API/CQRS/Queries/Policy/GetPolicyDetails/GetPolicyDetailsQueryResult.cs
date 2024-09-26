using Microservices.Demo.Policy.API.CQRS.Queries.Infrastructure.Dtos.Policy;

namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.GetPolicyDetails
{
    public class GetPolicyDetailsQueryResult
    {
        public PolicyDetailsDto Policy { get; set; }
    }
}
