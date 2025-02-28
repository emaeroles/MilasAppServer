using Application.DTOs._01_Common;
using Application.DTOs.Product;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Product
{
    public class UpdateProductUseCase
    {
        private readonly IUpdateRepo<ProductEntity> _updateRepo;
        private readonly IMapper _mapper;

        public UpdateProductUseCase(
            IUpdateRepo<ProductEntity> updateRepo,
            IMapper mapper)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateProductInput updateProductInput)
        {
            var productEntity = _mapper.Map<ProductEntity>(updateProductInput);

            var isOk = await _updateRepo.UpdateAsync(productEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound($"Product was not updated, " +
                    $"id {updateProductInput.Id} does not exist");

            return ResultFactory.CreateSuccess("Product was updated", null);
        }
    }
}
