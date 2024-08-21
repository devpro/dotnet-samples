using DotnetSamples.BlogDomain.Models;

namespace DotnetSamples.BlogDomain.Repositories;

public interface IBlogRepository
{
    Task<int> GetBlogPostCountAsync();
    Task<List<BlogPostModel>> GetBlogPostsAsync(int size, int start);
    Task<BlogPostModel?> GetBlogPostAsync(string id);
    Task<BlogPostModel?> SaveBlogPostAsync(BlogPostModel item);

    Task<List<CategoryModel>> GetCategoriesAsync();
    Task<CategoryModel?> GetCategoryAsync(string id);
    Task<CategoryModel?> SaveCategoryAsync(CategoryModel item);
    Task DeleteBlogPostAsync(string id);
    Task DeleteCategoryAsync(string id);

    Task<List<TagModel>> GetTagsAsync();
    Task<TagModel?> GetTagAsync(string id);
    Task<TagModel?> SaveTagAsync(TagModel item);
    Task DeleteTagAsync(string id);

    Task<List<CommentModel>> GetCommentsAsync(string blogPostId);
    Task<CommentModel?> SaveCommentAsync(CommentModel item);
    Task DeleteCommentAsync(string id);
}
