using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>
{
    public string Name { get; set; }

    //CQRS icin command ne ise handler de o dur. Birbiri ile calisirlar.
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreatedBrandResponse response = new CreatedBrandResponse();
            response.Name = request.Name;
            response.Id = new Guid();

            return response;
        }
    }
}
