using SabayNew.Models;

namespace SabayNew.Repository.Content
{
    public interface IContentRepository
    {
        public Task<List<ContentModel>> GetAll();
        public Task<bool> Save(ContentModel contect);

        public Task<bool> Update(ContentModel contect, int id);

        public Task<bool> Delete(int id);
        public Task<ContentModel> GetById(int id);
        public Task<ContentModel> GetByName(string name);
    }
}
