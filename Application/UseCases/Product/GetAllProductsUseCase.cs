using Application.DTOs._01_Common;
using Application.DTOs.Product;
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
            IEnumerable<ProductEntity>? listProductsEntity = await _getAllByActiveRepo.GetAllByActiveAsync(isActive);

            if (listProductsEntity == null)
                return ResultFactory.CreateNotFound("There are no products");

            IEnumerable<GetProductOutput> listGetProductsOutput = listProductsEntity
                .Select(productEntity => _mapper.Map<GetProductOutput>(productEntity));

            return ResultFactory.CreateData("Products", listGetProductsOutput);
        }
    }
}
