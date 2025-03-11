using Application.DTOs._01_Common;
using Application.DTOs.Visit;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.ProductKiosco;
using Application.Interfaces.Visit;

namespace Application.UseCases.Visit
{
    public class AddVisitUseCase
    { 
        private readonly IAddVisitAndUptadeStockRepo _addAndUpdateRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdKioscoRepo;
        private readonly IGetByIdComposedRepo<ProductKioscoEntity> _getByIdProductKioscoRepo;
        private readonly IGetAllProductsKioscoRepo _getAllProductsKioscoRepo;

        public AddVisitUseCase(
            IAddVisitAndUptadeStockRepo addAndUpdateRepo,
            IGetByIdRepo<KioscoEntity> getByIdKioscoRepo,
            IGetByIdComposedRepo<ProductKioscoEntity> getByIdProductKioscoRepo,
            IGetAllProductsKioscoRepo getAllProductsKioscoRepo)
        {
            _addAndUpdateRepo = addAndUpdateRepo;
            _getByIdKioscoRepo = getByIdKioscoRepo;
            _getByIdProductKioscoRepo = getByIdProductKioscoRepo;
            _getAllProductsKioscoRepo = getAllProductsKioscoRepo;
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

            IEnumerable<ProductKioscoEntity>? listProductKioscoEntitiesCheck = await _getAllProductsKioscoRepo
                .GetAllProductsKioscoAsync(addVisitInput.KioscoId);

            if(listProductKioscoEntitiesCheck == null)
                return ResultFactory.CreateNotFound("The kiosco has no products.");

            if (addVisitInput.VisitDetails.Count() != listProductKioscoEntitiesCheck.Count())
                return ResultFactory.CreateConflict("Should send a detailed list with all the " +
                    "products from the kiosco");

            List<ProductKioscoEntity> listProductKioscoEntities = new List<ProductKioscoEntity>();
            foreach (AddVisitDetailInput visitDetail in addVisitInput.VisitDetails)
            {
                ProductKioscoEntity? productKioscoEntity = await _getByIdProductKioscoRepo
                    .GetByIdComposedAsync(visitDetail.ProductId, addVisitInput.KioscoId);

                if (productKioscoEntity == null)
                    return ResultFactory.CreateNotFound($"The product Id {visitDetail.ProductId} " +
                        $"by kiosco Id {addVisitInput.KioscoId} does not exist");

                if (listProductKioscoEntities.Any(p => p.ProductId == productKioscoEntity.ProductId))
                    return ResultFactory.CreateConflict($"The product with Id {visitDetail.ProductId} " +
                        $"is duplicated.");

                if(visitDetail.Has > productKioscoEntity.Stock)
                    return ResultFactory.CreateConflict($"The quantity of products with Id " +
                        $"{visitDetail.ProductId} that it has cannot exceed the stock.");

                if (visitDetail.Has < visitDetail.Changes)
                    return ResultFactory.CreateConflict($"The number of changes for the product with Id " +
                        $"{visitDetail.ProductId} cannot be greater than what it has.");

                listProductKioscoEntities.Add(productKioscoEntity);
            }

            foreach (AddVisitDetailInput visitDetail in addVisitInput.VisitDetails)
            {
                VisitDetailEntity visitDetailEntity = new VisitDetailEntity();
                visitDetailEntity.Id = Guid.NewGuid();
                visitDetailEntity.Product.Id = visitDetail.ProductId;
                visitDetailEntity.Has = visitDetail.Has;
                visitDetailEntity.Leave = visitDetail.Leave;
                visitDetailEntity.Changes = visitDetail.Changes;
                visitDetailEntity.Sold = listProductKioscoEntities
                    .FirstOrDefault(p => p.ProductId == visitDetail.ProductId)!.Stock - visitDetail.Has;
                visitDetailEntity.HistSalePrice = listProductKioscoEntities
                    .FirstOrDefault(p => p.ProductId == visitDetail.ProductId)!.KioscoSalePrice;

                visitEntity.VisitDetails.Add(visitDetailEntity);

                listProductKioscoEntities.FirstOrDefault(
                    p => p.ProductId == visitDetail.ProductId)!.Stock = visitDetail.Has + visitDetail.Leave;
            }

            bool isCreated = await _addAndUpdateRepo.AddAndUpdateAsync(visitEntity, listProductKioscoEntities);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The visit was not created");

            return ResultFactory.CreateCreated("The visit was created", visitEntity.Id);
        }
    }
}
