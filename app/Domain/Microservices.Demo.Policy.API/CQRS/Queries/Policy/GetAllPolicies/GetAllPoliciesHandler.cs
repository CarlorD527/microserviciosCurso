using MediatR;
using Microservices.Demo.Policy.API.CQRS.Queries.Infrastructure.Dtos.Policy;
using Microservices.Demo.Policy.API.Infrastructure.Data.Repository;

namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.GetAllPolicies
{

    public class GetAllPoliciesHandler : IRequestHandler<GetAllPoliciesQuery, IEnumerable<PolicyReportDto>>
    {
        private readonly IPolicyRepository _policyRepository;

        public GetAllPoliciesHandler(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository ?? throw new ArgumentNullException(nameof(_policyRepository)); ;
        }

        public async Task<IEnumerable<PolicyReportDto>> Handle(GetAllPoliciesQuery request, CancellationToken cancellationToken)
        {

            // Obtener todas las pólizas desde el repositorio
            var policies = await _policyRepository.GetAllPoliciesAsync();

            return policies.Select(p => new PolicyReportDto
            {
                Number = p.Number,
                ProductCode = p.ProductCode,
                PolicyHolder = p.AgentLogin,

            }).ToList();
        }
    }
    
}
