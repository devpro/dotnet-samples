namespace DotnetSamples.BlogDomain.Models;

public class BlogPostModel
{
    public string? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
    public CategoryModel? Category { get; set; }
    public List<TagModel> Tags { get; set; } = [];
}
