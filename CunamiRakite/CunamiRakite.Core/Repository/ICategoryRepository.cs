using CSharpFunctionalExtensions;
using CunamiRakite.Core.Entities;
using System;
using System.Collections.Generic;

namespace CunamiRakite.Core.Repository
{
  public interface ICategoryRepository
    {
        IEnumerable<Category> FindAll();

        void Add(Category category);

        void Update(Category category);

        void Remove(Guid id);

        Maybe<Category> FindById(Guid id);

        Maybe<Category> FindByIdOrName(Category category);
    }
}