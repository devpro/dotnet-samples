using AutoMapper;
using DotnetSamples.BlogDomain.Models;
using DotnetSamples.BlogDomain.Repositories;
using DotnetSamples.BlogInfraMongoDb.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace DotnetSamples.BlogInfraMongoDb;

public class BlogRepository(BlogDbContext blogDbContext, IMapper mapper) : IBlogRepository
{
    private readonly BlogDbContext _blogDbContext = blogDbContext;

    private readonly IMapper _mapper = mapper;

    public async Task<List<CategoryModel>> GetCategoriesAsync()
    {
        return _mapper.Map<List<CategoryModel>>(await _blogDbContext.Categories.ToListAsync());
    }

    public async Task<CategoryModel?> GetCategoryAsync(string id)
    {
        var objectId = ParseObjectId(id);
        return _mapper.Map<CategoryModel?>(await _blogDbContext.Categories.FirstOrDefaultAsync(x => x.Id == objectId));
    }

    public async Task<CategoryModel?> SaveCategoryAsync(CategoryModel item)
    {
        var entity = _mapper.Map<Category>(item);

        if (string.IsNullOrEmpty(item.Id))
        {
            _blogDbContext.Categories.Add(entity);
        }
        else
        {
            var existing = await _blogDbContext.Categories.FirstOrDefaultAsync(x => x.Id == entity.Id)
                ?? throw new Exception("Blog category cannot be updated as it doesn't exist");

            existing.Name = entity.Name;
        }

        await _blogDbContext.SaveChangesAsync();
        return _mapper.Map<CategoryModel>(entity);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        var objectId = ParseObjectId(id);
        var existing = await _blogDbContext.Categories.FirstOrDefaultAsync(x => x.Id == objectId);
        if (existing != null)
        {
            _blogDbContext.Categories.Remove(existing);
            await _blogDbContext.SaveChangesAsync();
        }
    }

    public Task DeleteBlogPostAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCommentAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTagAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPostModel?> GetBlogPostAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetBlogPostCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<BlogPostModel>> GetBlogPostsAsync(int size, int start)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentModel>> GetCommentsAsync(string blogPostId)
    {
        throw new NotImplementedException();
    }

    public Task<TagModel?> GetTagAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TagModel>> GetTagsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BlogPostModel?> SaveBlogPostAsync(BlogPostModel item)
    {
        throw new NotImplementedException();
    }

    public Task<CommentModel?> SaveCommentAsync(CommentModel item)
    {
        throw new NotImplementedException();
    }

    public Task<TagModel?> SaveTagAsync(TagModel item)
    {
        throw new NotImplementedException();
    }

    protected static ObjectId ParseObjectId(string id)
    {
        if (string.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out var objectId))
        {
            throw new ArgumentException($"{id} is not a valid object id.", nameof(id));
        }

        return objectId;
    }
}
