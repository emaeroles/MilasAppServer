using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class AddSupplyUseCase
    {
        private readonly IAddRepo<SupplyEntity> _addSupplyRepo;
        private readonly IGetByIdRepo<UomEntity> _getByIdRepo;
        private readonly IMapper _mapper;

        public AddSupplyUseCase(
            IAddRepo<SupplyEntity> addSupplyRepo,
            IGetByIdRepo<UomEntity> getByIdRepo,
            IMapper mapper)
        {
            _addSupplyRepo = addSupplyRepo;
            _getByIdRepo = getByIdRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddSupplyInput addSupplyInput)
        {
            UomEntity? uomEntity = await _getByIdRepo.GetByIdAsync(addSupplyInput.UomId);
            if (uomEntity == null)
                return ResultFactory.CreateNotFound("The unit of measure was not found");

            SupplyEntity supplyEntity = _mapper.Map<SupplyEntity>(addSupplyInput);
            supplyEntity.Id = Guid.NewGuid();
            supplyEntity.IsActive = true;

            bool isCreated = await _addSupplyRepo.AddAsync(supplyEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The supply was not created");

            return ResultFactory.CreateCreated("The supply was created", supplyEntity.Id);
        }
    }
}
