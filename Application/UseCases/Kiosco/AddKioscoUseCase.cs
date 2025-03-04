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
        private readonly IGetByIdRepo<UserEntity> _getByIdRepo;
        private readonly IMapper _mapper;

        public AddKioscoUseCase(
            IAddRepo<KioscoEntity> addKioscoRepo,
            IGetByIdRepo<UserEntity> getByIdRepo,
            IMapper mapper)
        {
            _addKioscoRepo = addKioscoRepo;
            _getByIdRepo = getByIdRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddKioscoInput addKioscoInput)
        {
            var kioscoEntity = _mapper.Map<KioscoEntity>(addKioscoInput);
            kioscoEntity.Id = Guid.NewGuid();
            kioscoEntity.IsEnableChanges = false;
            kioscoEntity.Notes = string.Empty;
            kioscoEntity.Dubt = 0;
            kioscoEntity.Order = Guid.Empty;
            kioscoEntity.IsActive = true;

            var userEntity = await _getByIdRepo.GetListByAsync(addKioscoInput.UserId);
            if(userEntity.Id == Guid.Empty)
                return ResultFactory.CreateNotFound("User was not found");

            bool isCreated = await _addKioscoRepo.AddAsync(kioscoEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("Kiosco was not created");

            return ResultFactory.CreateCreated("Kiosco was created");
        }
    }
}
