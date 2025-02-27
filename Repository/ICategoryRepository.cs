using SabayNew.Models;

namespace SabayNew.Repository
{
    public interface ICategoryRepository
    {
        public Task<bool> Save(CategoryModel category);
        public Task<List<CategoryModel>>GetAll();
        public Task<CategoryModel> GetById(int id);
        Task<bool> Update(int id, CategoryModel category);
        public Task<bool> Delete(int id);
        public Task<CategoryModel> GetByName(string name);
    }
}
