﻿
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities.Common;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repositories.Interfaces.Generics;

namespace Portfolio.DAL.Repositories.Implementations.Generics
{
    public class CommandRepo<TEntity> : ICommandRepo<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly PortfolioDbContext _context;


        public CommandRepo(PortfolioDbContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var existingEntity = await Table.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new Exception($"{entity} not found");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        }
    }
}
