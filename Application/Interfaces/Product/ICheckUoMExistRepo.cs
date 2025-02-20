using Application.Enums;
using BL_Business.Entities;

namespace Application.Interfaces.Product
{
    public interface ICheckUoMExistRepo
    {
        public Task<bool> CheckUoMExistAsync(int uomId);
    }
}
