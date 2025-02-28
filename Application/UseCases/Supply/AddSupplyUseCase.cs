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
        private readonly IMapper _mapper;

        public AddSupplyUseCase(
            IAddRepo<SupplyEntity> addSupplyRepo,
            IMapper mapper)
        {
            _addSupplyRepo = addSupplyRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddSupplyInput addSupplyInput)
        {
            var supplyEntity = _mapper.Map<SupplyEntity>(addSupplyInput);

            int id = await _addSupplyRepo.AddAsync(supplyEntity);

            if (id == 0)
                return ResultFactory.CreateNotFound("Supply was not created");

            return ResultFactory.CreateCreated("Supply was created", id);
        }
    }
}
