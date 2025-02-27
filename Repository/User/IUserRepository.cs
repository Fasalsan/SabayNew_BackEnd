using SabayNew.Models;

namespace SabayNew.Repository.User
{
    public interface IUserRepository
    {
        public Task<List<UserModel>> GetAll();
        public Task<UserModel> GetById(int id);
        public Task<UserModel> GetByEmail(string email);
      
        public Task<bool>Save(UserModel user);
        public Task<bool>Update(UserModel user , int id);
        public Task<bool>Delete(int id);

    }
}
