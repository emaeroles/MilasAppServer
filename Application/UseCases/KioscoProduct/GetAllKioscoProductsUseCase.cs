using Application.DTOs._01_Common;
using Application.DTOs.KioscoProduct;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.KioscoProduct;
using AutoMapper;

namespace Application.UseCases.KioscoProduct
{
    public class GetAllKioscoProductsUseCase
    {
        private readonly IGetAllKioscoProductsRepo _getAllKioscoProductsRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdRepo;
        private readonly IMapper _mapper;

        public GetAllKioscoProductsUseCase(
            IGetAllKioscoProductsRepo getAllKioscoProductsRepo,
            IGetByIdRepo<KioscoEntity> getByIdRepo,
            IMapper mapper)
        {
            _getAllKioscoProductsRepo = getAllKioscoProductsRepo;
            _getByIdRepo = getByIdRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(Guid kioscoId)
        {
            KioscoEntity? kioscoEntity = await _getByIdRepo.GetByIdAsync(kioscoId);
            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco was not found");

            IEnumerable<KioscoProductEntity>? listKioscoProductsEntity =
                await _getAllKioscoProductsRepo.GetAllKioscoProductsAsync(kioscoId);

            if (listKioscoProductsEntity == null)
                return ResultFactory.CreateNotFound("There are no products");

            IEnumerable<GetKioscoProductOutput> listGetKioscoProductOutput = listKioscoProductsEntity
                .Select(kioscoProductEntity => _mapper.Map<GetKioscoProductOutput>(kioscoProductEntity));

            return ResultFactory.CreateData("Products", listGetKioscoProductOutput);
        }
    }
}
