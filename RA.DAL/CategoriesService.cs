﻿using Microsoft.EntityFrameworkCore;
using RA.Database;
using RA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDbContextFactory<AppDbContext> dbContextFactory;

        public CategoriesService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<CategoryDto>> GetRootCategoriesAsync()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.GetRootCategories()
                .Select(c => CategoryDto.FromEntity(c))
                .ToListAsync();
        }

        public async Task<bool> HasCategoryChildren(int categoryId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.Categories
                .Where(c => c.ParentId == categoryId)
                .AnyAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetChildrenCategoriesAsync(int parentCategoryId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.Categories
                .Where(c => c.ParentId == parentCategoryId)
                .Select(c => CategoryDto.FromEntity(c))
                .ToListAsync();
        }


        public async Task<CategoryHierarchyDto> GetCategoryHierarchy(int categoryId)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.CategoriesHierarchy
                        .Where(ch => ch.Id == categoryId)
                        .Select(ch => CategoryHierarchyDto.FromEntity(ch))
                        .FirstOrDefaultAsync();
        }

    }
}
