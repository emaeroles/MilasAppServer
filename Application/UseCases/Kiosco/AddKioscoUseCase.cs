using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class AddKioscoUseCase
    {
        private readonly IAddRepo<KioscoEntity> _addKioscoRepo;
        private readonly IMapper _mapper;

        public AddKioscoUseCase(
            IAddRepo<KioscoEntity> addKioscoRepo,
            IMapper mapper)
        {
            _addKioscoRepo = addKioscoRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddKioscoInput addKioscoInput)
        {
            var kioscoEntity = _mapper.Map<KioscoEntity>(addKioscoInput);

            int id = await _addKioscoRepo.AddAsync(kioscoEntity);

            if (id == 0)
                return ResultFactory.CreateCreated("Kiosco was not created", id);

            return ResultFactory.CreateCreated("Kiosco was created", id);
        }
    }
}
