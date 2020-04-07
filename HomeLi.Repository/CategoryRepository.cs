using HomeLi.Contracts.Repositories;
using HomeLi.Entities;
using HomeLi.Entities.ExtendedModels;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLi.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }
        
        public IEnumerable<Category> GetAllCategories()
        {
            return FindAll().OrderBy(c => c.Name);
        }

        public Category GetCategoryById(Guid id)
        {
            return FindByCondition(c => c.Id.Equals(id))
                .DefaultIfEmpty(new Category())
                .FirstOrDefault();
        }

        public CategoryExtended GetCategoryWithDetails(Guid id)
        {
            return new CategoryExtended(GetCategoryById(id))
            {
                Books = LibraryContext.Books
                    .Where(b => b.Categories
                        .Select(c => c.Id)
                        .Contains(id))
                    .ToArray()
            };
        }

        public void CreateCategory(Category category)
        {
            category.Id = Guid.NewGuid();
            Create(category);
            Save();
        }
        
        public void UpdateCategory(Category dbCategory, Category category)
        {
            dbCategory.Map(category);
            Update(dbCategory);
            Save();
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
            Save();
        }
    }
}
