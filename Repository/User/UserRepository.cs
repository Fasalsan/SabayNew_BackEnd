using Microsoft.EntityFrameworkCore;
using SabayNew.Dal;
using SabayNew.Models;

namespace SabayNew.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly NewSbyContext _context;

        public  UserRepository(NewSbyContext context)
        {
            _context = context;
        } 

        public async Task<List<UserModel>> GetAll()
        {
            try
            {
                var queryble = _context.Users;
                queryble.Include(r => r.Role);

                var isUser = await queryble.Select(u => new UserModel
                {
                    roleModel = new RoleModel
                    {
                        RoleId = u.Role.RoleId,
                        RoleName = u.Role.RoleName,
                    },
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password= u.Password,
                    RoleId = u.RoleId,

                }).ToListAsync();
                return isUser;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetEmail(string email)
        {
            return "abc";
        }
        public int GetNumber(int a)
        {
            return 1;
        }
        //public UserModel getUser(int id)
        //{
        //    return new User();
        //}

        public async Task<UserModel> GetByEmail(string email)
        {
            try
            {
                var result = await _context.Users
                .Include(r => r.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
                if(result == null)
                {
                    throw new Exception("User Not Found");
                }
                return new UserModel
                {
                    Id = result.Id,
                    FirstName = result?.FirstName,
                    LastName = result?.LastName,
                    Email = result?.Email,
                    Password = result?.Password,
                    RoleId = result?.RoleId,

                    roleModel = new RoleModel
                    {
                        RoleId = result.Role.RoleId,
                        RoleName = result?.Role.RoleName,

                    }

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> GetById(int id)
        {
            try
            {
                var result = await _context.Users
                .Include(r => r.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
                return new UserModel
                {
                    Id = result.Id,
                    FirstName = result?.FirstName,
                    LastName = result?.LastName,
                    Email = result?.Email,
                    Password = result?.Password,
                    RoleId = result?.RoleId,
                   
                    roleModel = new RoleModel
                    {
                        RoleId = result.Role.RoleId,
                        RoleName = result?.Role.RoleName,

                    }

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Save(UserModel user)
        {
            try
            {
                var userDb = await _context.Users.Where(u => u.Email.Equals(user.Email)).FirstOrDefaultAsync();



                if (userDb != null)
                {
                    throw new Exception("alrady user");
                }
                else
                {
                    var isNewUser = new Dal.User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        RoleId = user.RoleId,
                    };
                    _context.Users.Add(isNewUser);
                    await _context.SaveChangesAsync();
                    return true;
                }
           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        public async Task<bool> Update(UserModel user, int id)
        {
            try
            {
                 var isUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if(isUser != null)
                {
                    isUser.FirstName = user.FirstName;
                    isUser.LastName = user.LastName;
                    isUser.Email = user.Email;
                    isUser.Password = user.Password;
                    isUser.RoleId = user.RoleId;

                    _context.Entry(isUser).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var savingUser = new Dal.User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        RoleId = user.RoleId,
                    };
                    _context.Users.Add(savingUser);
                    await _context.SaveChangesAsync();
                }
                return true;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        async Task<bool> IUserRepository.Delete(int id)
        {
            try
            {
                var isUser = await _context.Users.FirstOrDefaultAsync(u =>u.Id == id);
                if (isUser != null)
                {
                    _context.Remove(isUser);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
    }
