using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunamiRakite.Core.Entities
{
   public  class Category
    {
        public Guid Id { get; }
        public string Name { get; }


        private Category(Guid id, string name) {

            this.Id = id;
            this.Name = name;
        }


        public static Result<Category> Create(Guid id, string name) {


            if (id == Guid.Empty) return Result.Failure<Category>("id cannot be null");

            var catName = CategoryName.Create(name);

            var result = Result.Combine(catName);
            if (result.IsFailure) return Result.Failure<Category>(result.Error);

            return Result.Success(new Category(id, name));
        }
    }
}
