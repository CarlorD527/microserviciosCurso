
namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.GetAllPolicies
{
    using MediatR;
    using Microservices.Demo.Policy.API.CQRS.Queries.Infrastructure.Dtos.Policy;
    using Microservices.Demo.Policy.API.Infrastructure.Data.Repository;
    using Microservices.Demo.Policy.API.Infrastructure.Data.Entities;
    using Microservices.Demo.Policy.API.CQRS.Queries.Policy.GetPolicyDetails;
    using System.Threading.Tasks;
    using System.Threading;

    public class GetAllPoliciesHandler : IRequestHandler<GetAllPoliciesQuery, GetAllPoliciesQueryResult>
    {
        private readonly IPolicyRepository _policyRepository;

        public GetAllPoliciesHandler(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public async Task<GetAllPoliciesQueryResult> Handle(GetAllPoliciesQuery request, CancellationToken cancellationToken)
        {
            // Obtener todas las pólizas desde el repositorio
            var policies = await _policyRepository.GetAllPoliciesAsync();

            // Mapear las pólizas a PolicyDetailsDto
            var policyDetailsDtos = policies.Select(policy => new PolicyDetailsDto
            {
                Number = policy.Number,
                PolicyHolder = policy.AgentLogin,
                ProductCode = policy.ProductCode,
            }).ToList();

            // Crear el resultado a devolver
            return new GetAllPoliciesQueryResult
            {
                Policies = policyDetailsDtos
            };
        }

    }
    
}
