namespace DotnetSamples.BlogDomain.Models;

public class CommentModel
{
    public string? Id { get; set; }
    public required string BlogPostId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
