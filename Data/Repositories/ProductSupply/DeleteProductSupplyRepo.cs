﻿using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductSupply
{
    public class DeleteProductSupplyRepo : IDeleteComposedRepo<ProductSupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public DeleteProductSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> DeleteComposedAsync(Guid entityId, Guid byEntityId)
        {
            var productSupply = new Dictionary<string, object>
            {
                { "ProductId", entityId },
                { "SupplyId", byEntityId }
            };

            _dbcontext.Set<Dictionary<string, object>>("ProductSupply").Remove(productSupply);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
