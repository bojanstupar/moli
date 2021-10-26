using CSharpFunctionalExtensions;
using CunamiRakite.Core.Entities;
using CunamiRakite.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunamiRakite.Core.Services
{
   public class CategoryService
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) {

            this.categoryRepository = categoryRepository;
        }


        public Result Save(Category category) {

            var maybeCategory = categoryRepository.FindByIdOrName(category);
            if (maybeCategory.HasValue) return Result.Failure<Category>("Already exist category with than name and id");

            categoryRepository.Add(maybeCategory.Value);
            return Result.Success();
        }

        public Result Update(Category category) {

            var maybeCategory = categoryRepository.FindById(category.Id);
            if (maybeCategory.HasNoValue) return Result.Failure<Category>("that id doesn't exist");

            categoryRepository.Update(maybeCategory.Value);
            return Result.Success();
        }

        public Result Remove(Guid id) { 
        
             var maybeCategory = categoryRepository.FindById(id);
            if (maybeCategory.HasNoValue) return Result.Failure<Category>("that id doesn't exist");

            categoryRepository.Remove(id);

            return Result.Success();
        }
    }
}
