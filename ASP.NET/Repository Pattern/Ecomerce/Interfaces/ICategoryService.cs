using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.DTOs;

namespace Ecomerce.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryReadDto> GetAllCategory();

        CategoryReadDto? GetCategoryById(Guid id);

        CategoryReadDto CreateCategory(CategoryCreateDto category_data);

        CategoryReadDto CreateManual();

        CategoryReadDto? CategoryUpdate(Guid id, CategoryUpdateDto category_data);

        bool  CategoryDelete(Guid id);

    }
}