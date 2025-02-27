using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SabayNew.Dal;
using SabayNew.Models;

namespace SabayNew.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NewSbyContext _context;
        public int CategoryId { get; set; }
        public CategoryRepository(NewSbyContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            try
            {
                var categoryDB = await _context.Categories.Select(ca => new CategoryModel
                {
                    Id = ca.Id,
                    Name = ca.Name,
                }).ToListAsync();
                return categoryDB;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryModel> GetById(int id)
        {
            try
            {
                var categoryDB = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (categoryDB != null)
                    return new CategoryModel
                    {
                        Id = categoryDB!.Id,
                        Name = categoryDB.Name
                    };
                else
                {
                    throw new Exception("CategoryID Not Found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(int id, CategoryModel category)
        {
            try
            {
                var categoryDB = await _context.Categories.FirstOrDefaultAsync(ca => ca.Id == id);
                if (categoryDB != null)
                {
                    categoryDB.Name = category.Name;

                    _context.Entry(categoryDB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Not Found ID");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Save(CategoryModel category)
        {
            try
            {
                var categoryDB = new Category
                {
                    Id = category.Id,
                    Name = category.Name

                };
                _context.Categories.Add(categoryDB);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var categoryDB = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (categoryDB != null)
                {
                    _context.Remove(categoryDB);
                    await _context.SaveChangesAsync();
                    

                }
                else
                {
                    throw new Exception("CategoryID not Found");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryModel> GetByName(string name)
        {
            try
            {
                var categoryDB = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
                return new CategoryModel
                {
                    Id = categoryDB!.Id,
                    Name = categoryDB.Name
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
