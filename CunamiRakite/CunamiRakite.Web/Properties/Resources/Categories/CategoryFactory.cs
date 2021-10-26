using CSharpFunctionalExtensions;
using CunamiRakite.Core.Entities;
using CunamiRakite.Web.Properties.Resources.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CunamiRakite.Web.Properties.Resources.Categories
{
    public class CategoryFactory
    {

        public static Result<Category> Create(CategoryDto dto) {

            return Category.Create(Guid.NewGuid(), dto.CatName);
        }
    }
}
