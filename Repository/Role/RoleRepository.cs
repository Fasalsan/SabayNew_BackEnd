using Microsoft.EntityFrameworkCore;
using SabayNew.Dal;
using SabayNew.Models;

namespace SabayNew.Repository.Role
{
    public class RoleRepository : IRoleRepository

    {
        private readonly NewSbyContext _context;
         public RoleRepository(NewSbyContext context)
        {
            _context = context;
        }
        public async Task<List<RoleModel>> GetAll()
        {
            try
            {

                var isRole = await _context.Roles.Select(r => new RoleModel
                {
                  RoleId =r.RoleId,
                  RoleName =r.RoleName,
                }).ToListAsync();
                return isRole;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoleModel> GetById(int id)
        {
            try
            {
                var isRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
                return new RoleModel
                {
                    RoleId = isRole.RoleId,
                    RoleName = isRole.RoleName,

                };
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(int id, RoleModel role)
        {
            try
            {
                var isRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
                if(isRole != null)
                {
                    isRole.RoleName = role.RoleName;
                    _context.Entry(isRole).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
                return true;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       public async Task<bool> Delete(int id)
        {
            try
            {
                var isRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
                if (isRole != null)
                {
                    _context.Remove(isRole);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
                return true;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Save(RoleModel role)
        {
            try
            {
                var NewRole = new Dal.Role
                {
                    RoleName = role.RoleName,
                };
                _context.Roles.Add(NewRole);
                await _context.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                    throw new Exception(ex.Message);
            }
        }


        //public Task<RoleModel> GetByName(string name)
        //{
        //    try
        //    {
        //        var isRoleName = await _context.Roles.FirstOrDefaultAsync(r => r.Name === name);
        //        return new RoleModel
        //        {
        //            Id = isRoleName.Id,
        //            Name = isRoleName.Name,

        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
