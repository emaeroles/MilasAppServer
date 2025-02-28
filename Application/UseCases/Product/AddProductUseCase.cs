using Application.DTOs._01_Common;
using Application.DTOs.Product;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Product
{
    public class AddProductUseCase
    {
        private readonly IAddRepo<ProductEntity> _addProductRepo;
        private readonly IMapper _mapper;

        public AddProductUseCase(
            IAddRepo<ProductEntity> addProductRepo,
            IMapper mapper)
        {
            _addProductRepo = addProductRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddProductInput addProductInput)
        {
            var productEntity = _mapper.Map<ProductEntity>(addProductInput);

            int id = await _addProductRepo.AddAsync(productEntity);

            if (id == 0)
                return ResultFactory.CreateNotFound("Product was not created");

            return ResultFactory.CreateCreated("Product was created", id);
        }
    }
}
