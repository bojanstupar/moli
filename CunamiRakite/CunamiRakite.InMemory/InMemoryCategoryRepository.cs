using CSharpFunctionalExtensions;
using CunamiRakite.Core.Entities;
using CunamiRakite.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CunamiRakite.InMemory
{
   public  class InMemoryCategoryRepository:ICategoryRepository
    {

        public readonly List<Category> categories;

        public InMemoryCategoryRepository() {

            categories = new List<Category> {

                Category.Create(Guid.NewGuid(),"Dizajn").Value,Category.Create(Guid.NewGuid(),"web").Value,
                Category.Create(Guid.NewGuid(),"Java").Value
             };

 }
        public IEnumerable<Category> FindAll() {

            return categories;
        }

        public Maybe<Category> FindById(Guid id) {

            return categories.Find(c => c.Id == id);
        }

        public void Add(Category category) {

            categories.Add(category);
        }

        public void Update(Category category) {


            categories.RemoveAll(c =>c.Id==category.Id);
            categories.Add(category);
        }

        public void Remove(Guid id) {

            categories.RemoveAll(c => c.Id == id);
        }

        public Maybe<Category> FindByIdOrName(Category category) {

            return categories.Find(c => c.Id == category.Id || c.Name == category.Name);
        }
    }
}
