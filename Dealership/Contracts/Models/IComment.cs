namespace Dealership.Contracts.Models
{
    public interface IComment
    {
        string Content { get; }

        string Author { get; set; }
    }
}
