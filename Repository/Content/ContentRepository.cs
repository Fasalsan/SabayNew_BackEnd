using Microsoft.EntityFrameworkCore;
using SabayNew.Dal;
using SabayNew.Models;

namespace SabayNew.Repository.Content
{
    public class ContentRepository : IContentRepository
    {
        private readonly NewSbyContext _context;

        public ContentRepository(NewSbyContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var isContent = await _context.Contents.FirstOrDefaultAsync(c => c.Id == id);

                if (isContent != null)
                {
                    _context.Remove(isContent);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Not Found ContentID");
                }
                  return true;


            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ContentModel>> GetAll()
        {
            try
            {
                var queryble = _context.Contents;
                queryble.Include(ca => ca.Category);

                var isContent = await queryble.Select(c => new ContentModel
                {
                 

                    Id = c.Id,
                    Tiltle = c.Tiltle,
                    ImageUrl = c.ImageUrl,
                    CreatedBy = c.CreatedBy,
                    CreatedDate = DateTime.Now,
                    CategoryId = c.CategoryId,

                    categoryModel = new CategoryModel
                    {
                      Id = c.Category.Id,
                      Name = c.Category.Name,
                   
                    },
                }).ToListAsync();
                return isContent;
    
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContentModel> GetById(int id)
        {
            try
            {
                var isID = await _context.Contents.FirstOrDefaultAsync(c => c.Id == id);
                if (isID != null)
                    return new ContentModel
                    {
                        Id = isID.Id,
                        Tiltle = isID.Tiltle,
                        ImageUrl = isID.ImageUrl,
                        CreatedBy = isID.CreatedBy,
                        CreatedDate = isID.CreatedDate,

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


        public async Task<ContentModel> GetByName(string name)
        {
            try
            {
                var queryble = _context.Contents;
                queryble.Include(ca => ca.Category);

                var item =  await queryble.FirstOrDefaultAsync(c => c.Tiltle == name);
                return new ContentModel
                {
                  Id = item.Id,
                  Tiltle = item.Tiltle,
                  ImageUrl = item.ImageUrl,
                  CreatedBy = item.CreatedBy,
                  CreatedDate = item.CreatedDate,
                  CategoryId = item.CategoryId,

                    categoryModel = new CategoryModel
                    {
                        Id = item.Category.Id,
                        Name = item.Category.Name,
                    }

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Save(ContentModel content)
        {
            try
            {
                var isContent = new Dal.Content
                {
                    Id = content.Id,
                    Tiltle = content.Tiltle,
                    ImageUrl = content.ImageUrl,
                    CreatedBy = content.CreatedBy,
                    CreatedDate = DateTime.Now,
                    CategoryId = content.CategoryId,
                };
                _context.Contents.Add(isContent);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(ContentModel contect, int id)
        {
            try
            {
                var isContent = await _context.Contents.FirstOrDefaultAsync(ca => ca.Id == id);

                if (isContent != null)
                {
                    isContent.Id = contect.Id;
                    isContent.Tiltle = contect.Tiltle;
                    isContent.ImageUrl = contect.ImageUrl;
                    isContent.UpdatedBy = contect.UpdatedBy;

                    _context.Entry(isContent).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var savingContent = new Dal.Content
                    {
                        Id = contect.Id,
                        Tiltle = contect.Tiltle,
                        ImageUrl = contect.ImageUrl,
                        CreatedBy = contect.CreatedBy,
                        CategoryId = contect.CategoryId,
                       CreatedDate = DateTime.Now,

                    };
                    _context.Contents.Add(savingContent);
                    await _context.SaveChangesAsync();
                }
                return true;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
