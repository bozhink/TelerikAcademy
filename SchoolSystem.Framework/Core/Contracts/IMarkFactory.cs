namespace SchoolSystem.Framework.Core.Contracts
{
    using SchoolSystem.Framework.Models.Contracts;
    using SchoolSystem.Framework.Models.Enums;

    public interface IMarkFactory
    {
        IMark CreateMark(Subject subject, float value);
    }
}
