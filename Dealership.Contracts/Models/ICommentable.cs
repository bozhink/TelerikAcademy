namespace Dealership.Contracts.Models
{
    using System.Collections.Generic;

    public interface ICommentable
    {
        IList<IComment> Comments { get; }
    }
}
