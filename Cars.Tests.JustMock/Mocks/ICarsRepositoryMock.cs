namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using System.Linq.Expressions;
    using System;

    public interface ICarsRepositoryMock
    {
        ICarsRepository CarsData { get; }

        void Verify(Expression<Action<ICarsRepository>> action);
    }
}
