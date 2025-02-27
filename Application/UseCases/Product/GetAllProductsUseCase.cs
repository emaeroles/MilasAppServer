using Application.DTOs._01_Common;
using Application.DTOs.Product;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Product
{
    public class GetAllProductsUseCase
    {
        private readonly IGetAllByActiveRepo<ProductEntity> _getAllByActiveRepo;
        private readonly IMapper _mapper;

        public GetAllProductsUseCase(
            IGetAllByActiveRepo<ProductEntity> getAllByActiveRepo,
            IMapper mapper)
        {
            _getAllByActiveRepo = getAllByActiveRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(bool isActive)
        {
            var listProductsEntity = await _getAllByActiveRepo.GetAllByActiveAsync(isActive);
            var listGetProductsOutput = listProductsEntity
                .Select(productEntity => _mapper.Map<GetProductOutput>(productEntity));

            return ResultFactory.CreateSuccess("Products", listGetProductsOutput);
        }
    }
}
