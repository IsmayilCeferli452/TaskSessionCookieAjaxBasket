using FiorelloAsp.Data;
using FiorelloAsp.Models;
using FiorelloAsp.Services.Interfaces;
using FiorelloAsp.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace FiorelloAsp.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(BlogCreateVM blog)
        {
            await _context.Blogs.AddAsync(new Blog
            {
                Title = blog.Title,
                Description = blog.Description,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogVM>> GetAllAsync(int? take = null)
        {
            IEnumerable<Blog> blogs;

            if(take is null)
            {
                blogs = await _context.Blogs.ToListAsync();
            }
            else
            {
                blogs = await _context.Blogs.Take((int)take).ToListAsync();
            }

            var datas = blogs.Select(m => new BlogVM { Id = m.Id, Title = m.Title, Description = m.Description,
                Image = m.Image, CreateDate = m.CreateDate.ToString("MM.dd.yyyy") }).OrderByDescending(m=> m.Id);

            return datas;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.Where(m => m.Id == id)
                                          .Include(m => m.BlogImages)
                                          .FirstOrDefaultAsync();
        }

        public async Task Delete(int id)
        {
            var blog = await GetByIdAsync(id);

            _context.Blogs.Remove(blog);

            await _context.SaveChangesAsync();
        }

        public async Task<Blog> GetAllWithIdAsync(int? id)
        {
            var category = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            return category;
        }
    }
}
