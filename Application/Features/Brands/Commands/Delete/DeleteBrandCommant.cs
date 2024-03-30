using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>
    {
        public Guid id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }
            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.id, withDeleted: false, cancellationToken: cancellationToken);

                brand = _mapper.Map(request, brand);

                await _brandRepository.DeleteAsync(brand);

                var response = _mapper.Map<DeletedBrandResponse>(brand);

                return response;
            }
        }
    }
}
