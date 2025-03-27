using Application.DTOs._01_Common;
using Application.DTOs.Visit;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.KioscoProduct;
using Application.Interfaces.Visit;

namespace Application.UseCases.Visit
{
    public class AddVisitUseCase
    { 
        private readonly IAddVisitAndUptadeStockRepo _addAndUpdateRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdKioscoRepo;
        private readonly IGetByIdComposedRepo<KioscoProductEntity> _getByIdKioscoProductRepo;
        private readonly IGetAllKioscoProductsRepo _getAllKioscoProductsRepo;

        public AddVisitUseCase(
            IAddVisitAndUptadeStockRepo addAndUpdateRepo,
            IGetByIdRepo<KioscoEntity> getByIdKioscoRepo,
            IGetByIdComposedRepo<KioscoProductEntity> getByIdKioscoProductRepo,
            IGetAllKioscoProductsRepo getAllKioscoProductsRepo)
        {
            _addAndUpdateRepo = addAndUpdateRepo;
            _getByIdKioscoRepo = getByIdKioscoRepo;
            _getByIdKioscoProductRepo = getByIdKioscoProductRepo;
            _getAllKioscoProductsRepo = getAllKioscoProductsRepo;
        }

        public async Task<AppResult> Execute(AddVisitInput addVisitInput)
        {
            KioscoEntity? kioscoEntity = await _getByIdKioscoRepo.GetByIdAsync(addVisitInput.KioscoId);
            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco does not exist");

            VisitEntity visitEntity = new VisitEntity();
            visitEntity.Id = Guid.NewGuid();
            visitEntity.Kiosco = kioscoEntity;
            visitEntity.Date = DateTime.Now;

            IEnumerable<KioscoProductEntity>? listKioscoProductEntitiesExist = await _getAllKioscoProductsRepo
                .GetAllKioscoProductsAsync(addVisitInput.KioscoId);

            if(listKioscoProductEntitiesExist == null)
                return ResultFactory.CreateNotFound("The kiosco has no products.");

            if (addVisitInput.VisitDetails.Count() != listKioscoProductEntitiesExist.Count())
                return ResultFactory.CreateConflict("Should send a detailed list with all the " +
                    "products from the kiosco");

            List<KioscoProductEntity> listKioscoProductEntities = new List<KioscoProductEntity>();
            foreach (AddVisitDetailInput visitDetail in addVisitInput.VisitDetails)
            {
                KioscoProductEntity? kioscoProductEntity = await _getByIdKioscoProductRepo
                    .GetByIdComposedAsync(visitDetail.ProductId, addVisitInput.KioscoId);

                if (kioscoProductEntity == null)
                    return ResultFactory.CreateNotFound($"The product Id {visitDetail.ProductId} " +
                        $"by kiosco Id {addVisitInput.KioscoId} does not exist");

                if (listKioscoProductEntities.Any(p => p.ProductId == kioscoProductEntity.ProductId))
                    return ResultFactory.CreateConflict($"The product with Id {visitDetail.ProductId} " +
                        $"is duplicated.");

                if(visitDetail.Has > kioscoProductEntity.Stock)
                    return ResultFactory.CreateConflict($"The quantity of products with Id " +
                        $"{visitDetail.ProductId} that it has cannot exceed the stock.");

                if (visitDetail.Has < visitDetail.Changes)
                    return ResultFactory.CreateConflict($"The number of changes for the product with Id " +
                        $"{visitDetail.ProductId} cannot be greater than what it has.");

                listKioscoProductEntities.Add(kioscoProductEntity);
            }

            foreach (AddVisitDetailInput visitDetail in addVisitInput.VisitDetails)
            {
                VisitDetailEntity visitDetailEntity = new VisitDetailEntity();
                visitDetailEntity.Id = Guid.NewGuid();
                visitDetailEntity.Product.Id = visitDetail.ProductId;
                visitDetailEntity.Has = visitDetail.Has;
                visitDetailEntity.Leave = visitDetail.Leave;
                visitDetailEntity.Changes = visitDetail.Changes;
                visitDetailEntity.Sold = listKioscoProductEntities
                    .FirstOrDefault(p => p.ProductId == visitDetail.ProductId)!.Stock - visitDetail.Has;
                visitDetailEntity.HistSalePrice = listKioscoProductEntities
                    .FirstOrDefault(p => p.ProductId == visitDetail.ProductId)!.KioscoSalePrice;

                visitEntity.VisitDetails.Add(visitDetailEntity);

                listKioscoProductEntities.FirstOrDefault(
                    p => p.ProductId == visitDetail.ProductId)!.Stock = visitDetail.Has + visitDetail.Leave;
            }

            bool isCreated = await _addAndUpdateRepo.AddAndUpdateAsync(visitEntity, listKioscoProductEntities);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The visit was not created");

            return ResultFactory.CreateCreated("The visit was created", visitEntity.Id);
        }
    }
}
