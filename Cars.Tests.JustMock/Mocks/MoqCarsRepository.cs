namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;
    using System;
    using System.Linq.Expressions;

    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        private Mock<ICarsRepository> mockedCarsRepository;

        public override void Verify(Expression<Action<ICarsRepository>> action)
        {
            this.mockedCarsRepository.Verify(action);
        }

        protected override void ArrangeCarsRepositoryMock()
        {
            this.mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository
                .Setup(r => r.Add(It.IsAny<Car>()))
                .Verifiable();

            mockedCarsRepository
                .Setup(r => r.Remove(It.IsAny<Car>()))
                .Verifiable();

            mockedCarsRepository
                .Setup(r => r.All())
                .Returns(this.FakeCarCollection);

            mockedCarsRepository
                .Setup(r => r.SortedByMake())
                .Returns(this.FakeCarCollection
                    .OrderBy(c => c.Make)
                    .ToList());

            mockedCarsRepository
                .Setup(r => r.SortedByYear())
                .Returns(this.FakeCarCollection
                    .OrderBy(c => c.Year)
                    .ToList());

            mockedCarsRepository
                .Setup(r => r.Search(It.IsAny<string>()))
                .Returns(this.FakeCarCollection
                    .Where(c => c.Make == "BMW")
                    .ToList());

            mockedCarsRepository
                .Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(this.FakeCarCollection.First());

            mockedCarsRepository
                .Setup(r => r.TotalCars)
                .Returns(this.FakeCarCollection.Count);

            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
