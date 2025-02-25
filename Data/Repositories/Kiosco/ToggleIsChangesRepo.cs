using Application.Interfaces.Kiosco;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class ToggleIsChangesRepo : IToggleIsChangesRepo
    {
        private readonly AppDbContext _dbcontext;

        public ToggleIsChangesRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> ToggleIsChangesAsync(int entityId)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entityId);

            if (kioscoModel == null)
                return false;

            kioscoModel.IsEnableChanges = !kioscoModel.IsEnableChanges;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
