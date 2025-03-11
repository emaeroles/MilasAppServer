using Application.DTOs._01_Common;
using Application.DTOs.Visit;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.Visit;
using AutoMapper;

namespace Application.UseCases.Visit
{
    public class GetVisitsUseCase
    {
        private readonly IGetStartingDateVisitsRepo _getStartingDateVisitsRepo;
        private readonly IMapper _mapper;

        public GetVisitsUseCase(
            IGetStartingDateVisitsRepo getStartingDateVisitsRepo,
            IMapper mapper)
        {
            _getStartingDateVisitsRepo = getStartingDateVisitsRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(DateOnly date, int quantity)
        {
            if(quantity > 10)
                return ResultFactory.CreateConflict("The quantity of visits should be less than 10");

            IEnumerable<VisitEntity>? listVisitsEntity = await _getStartingDateVisitsRepo
                .GetStartingDateVisitsAsync(date, quantity);

            if (listVisitsEntity == null)
                return ResultFactory.CreateNotFound("There are no visits");

            IEnumerable<GetVisitOutput> listGetVisitsOutput = listVisitsEntity
                .Select(visitEntity => _mapper.Map<GetVisitOutput>(visitEntity));

            return ResultFactory.CreateData("Visits", listGetVisitsOutput);
        }
    }
}
