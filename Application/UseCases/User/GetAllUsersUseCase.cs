using Application.DTOs._01_Common;
using Application.DTOs.User;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.User
{
    public class GetAllUsersUseCase
    {
        private readonly IGetAllByActiveRepo<UserEntity> _getAllByActiveRepo;
        private readonly IMapper _mapper;

        public GetAllUsersUseCase(
            IGetAllByActiveRepo<UserEntity> getAllByActiveRepo,
            IMapper mapper)
        {
            _getAllByActiveRepo = getAllByActiveRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(bool isActive)
        {
            IEnumerable<UserEntity>? listUserEntity = await _getAllByActiveRepo.GetAllByActiveAsync(isActive);

            if (listUserEntity == null)
                return ResultFactory.CreateNotFound("There are no users");

            IEnumerable<GetUserOutput> listGetUserOutput = listUserEntity
                .Select(userEntity => _mapper.Map<GetUserOutput>(userEntity));

            return ResultFactory.CreateData("Users", listGetUserOutput);
        }
    }
}
