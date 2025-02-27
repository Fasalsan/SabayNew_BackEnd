using SabayNew.Models;

namespace SabayNew.Repository.Role
{
    public interface IRoleRepository
    {
        public Task<bool>Save(RoleModel role);
        public Task<List<RoleModel>> GetAll();
        public Task<RoleModel> GetById(int id);

        public Task<bool>Update(int id, RoleModel role);

        public Task<bool> Delete(int id);

        //public Task<RoleModel> GetByName(string name);
    }
}
