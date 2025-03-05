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
            UserEntity? userEntity = await _getByIdRepo.GetByIdAsync(addKioscoInput.UserId);
            if(userEntity == null)
                return ResultFactory.CreateNotFound("The user was not found");

            KioscoEntity kioscoEntity = _mapper.Map<KioscoEntity>(addKioscoInput);
            kioscoEntity.Id = Guid.NewGuid();
            kioscoEntity.IsEnableChanges = false;
            kioscoEntity.Notes = string.Empty;
            kioscoEntity.Dubt = 0;
            kioscoEntity.Order = Guid.Empty;
            kioscoEntity.IsActive = true;

            bool isCreated = await _addKioscoRepo.AddAsync(kioscoEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The kiosco was not created");

            return ResultFactory.CreateCreated("The kiosco was created", kioscoEntity.Id);
        }
    }
}
