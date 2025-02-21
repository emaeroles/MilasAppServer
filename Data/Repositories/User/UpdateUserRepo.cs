﻿using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.User
{
    public class UpdateUserRepo : IUpdateRepo<UserEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateUserRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(UserEntity entity)
        {
            var userModel = await _dbcontext.Users.FindAsync(entity.Id);

            if (userModel == null)
                return false;

            userModel.Username = entity.Username;
            userModel.Password = entity.Password;
            userModel.Email = entity.Email;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
