using DotnetSamples.BlogDomain.Models;

namespace DotnetSamples.BlogDomain.Repositories;

public interface BlogRepository
{
    Task<int> GetBlogPostCountAsync();
    Task<List<BlogPostModel>> GetBlogPostsAsync(int size, int start);
    Task<List<CategoryModel>> GetCategoriesAsync();
    Task<List<TagModel>> GetTagsAsync();
    Task<List<CommentModel>> GetCommentsAsync(string blogPostId);
    Task<BlogPostModel?> GetBlogPostAsync(string id);
    Task<CategoryModel?> GetCategoryAsync(string id);
    Task<TagModel?> GetTagAsync(string id);
    Task<BlogPostModel?> SaveBlogPostAsync(BlogPostModel item);
    Task<CategoryModel?> SaveCategoryAsync(CategoryModel item);
    Task<TagModel?> SaveTagAsync(TagModel item);
    Task<CommentModel?> SaveCommentAsync(CommentModel item);
    Task DeleteBlogPostAsync(string id);
    Task DeleteCategoryAsync(string id);
    Task DeleteTagAsync(string id);
    Task DeleteCommentAsync(string id);
}
