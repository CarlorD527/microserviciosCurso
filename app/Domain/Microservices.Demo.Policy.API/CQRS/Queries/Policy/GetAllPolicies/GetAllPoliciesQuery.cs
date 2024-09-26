using Amazon.Runtime.Internal;
using MediatR;
using Microservices.Demo.Policy.API.CQRS.Queries.Infrastructure.Dtos.Policy;
using Microservices.Demo.Policy.API.CQRS.Queries.Policy.GetPolicyDetails;

namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.GetAllPolicies
{
    public class GetAllPoliciesQuery  : IRequest<GetAllPoliciesQueryResult>
    {
        // No se necesitan parametros.
    }
}
