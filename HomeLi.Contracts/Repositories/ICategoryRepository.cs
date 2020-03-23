using HomeLi.Entities.ExtendedModels;
using HomeLi.Entities.Models;
using System;
using System.Collections.Generic;

namespace HomeLi.Contracts.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Gets category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Category GetCategoryBy(Guid id);

        /// <summary>
        /// Gets category with extended details.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <returns></returns>
        CategoryExtended GetCategoryWithDetails(Guid id);

        /// <summary>
        /// Creates new category.
        /// </summary>
        /// <param name="category">The category.</param>
        void CreateCategory(Category category);

        /// <summary>
        /// Updated selected category with new values.
        /// </summary>
        /// <param name="dbCategory">The database category.</param>
        /// <param name="category">The category.</param>
        void UpdateCategory(Category dbCategory, Category category);

        /// <summary>
        /// Deletes category.
        /// </summary>
        /// <param name="category">The category.</param>
        void DeleteCategory(Category category);
    }
}
