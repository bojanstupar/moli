using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunamiRakite.Core.Entities
{
   public  class CategoryName:ValueObject
    {

        public string Value { get; }


        public  CategoryName(string name) {

            this.Value = name;
        }

        public static Result<CategoryName> Create(string name) {


            if (string.IsNullOrEmpty(name)) return Result.Failure<CategoryName>("cannot be null");

            if (name.Length > 30) return Result.Failure<CategoryName>("cannot be null");

            return Result.Success(new CategoryName(name));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
