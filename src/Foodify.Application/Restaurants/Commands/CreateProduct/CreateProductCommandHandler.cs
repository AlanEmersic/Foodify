using ErrorOr;
using Foodify.Application.Restaurants.Mappings;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Repositories;
using Foodify.Domain.Restaurants;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Created>>
{
    private readonly IProductRepository productRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        this.productRepository = productRepository;
        this.unitOfWork = unitOfWork;
    }


    public async Task<ErrorOr<Created>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        Product product = command.MapToDomain();
        await productRepository.AddAsync(product);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Created;
    }
}