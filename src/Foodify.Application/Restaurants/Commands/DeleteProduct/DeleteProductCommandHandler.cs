using ErrorOr;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Repositories;
using Foodify.Domain.Restaurants;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.DeleteProduct;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Deleted>>
{
    private readonly IProductRepository productRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        this.productRepository = productRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return Error.NotFound(description: "Product not found");
        }

        await productRepository.DeleteAsync(product);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}