namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private readonly ICarsRepositoryMock carsDataMock;
        private CarsController controller;

        public CarsControllerTests()
            ////: this(new JustMockCarsRepository())
            : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsDataMock = carsDataMock;
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarsController_AddCarWithNullMake_ShouldThrowArgumentNullException()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarsController_AddCarWithNullModel_ShouldThrowArgumentNullException()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarsController_AddNullCar_ShouldThrowArgumentNullException()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        public void CarsController_AddValidCar_ShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(2, model.Id);
            Assert.AreEqual("BMW", model.Make);
            Assert.AreEqual("325i", model.Model);
            Assert.AreEqual(2008, model.Year);
        }

        [TestMethod]
        public void CarsController_AddValidCar_ShouldWork()
        {
            var car = new Car
            {
                Id = 15,
                Make = "Pesho",
                Model = "xx-pesho-1",
                Year = 2016
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            this.carsDataMock.Verify(c => c.Add(car));
        }

        [TestMethod]
        public void CarsController_Details_ShouldReturnADetail()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(2, model.Id);
            Assert.AreEqual("BMW", model.Make);
            Assert.AreEqual("325i", model.Model);
            Assert.AreEqual(2008, model.Year);
        }

        [TestMethod]
        public void CarsController_Index_ShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void CarsController_SearchBMW_ShouldReturn2Cars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("BMW"));

            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        public void CarsController_SortByMake_ShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void CarsController_SortByMake_ShouldReturnSortedCars()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual("Audi", model[0].Make);
            Assert.AreEqual("BMW", model[1].Make);
            Assert.AreEqual("BMW", model[2].Make);
            Assert.AreEqual("Opel", model[3].Make);
        }

        [TestMethod]
        public void CarsController_SortByYear_ShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void CarsController_SortByYear_ShouldReturnSortedCars()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(2005, model[0].Year);
            Assert.AreEqual(2007, model[1].Year);
            Assert.AreEqual(2008, model[2].Year);
            Assert.AreEqual(2010, model[3].Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CarsController_SortByInvalidField_ShouldThrowArgumentException()
        {
            var model = (IList<Car>)this.GetModel(() => this.controller.Sort("pesho"));

            Assert.Fail("Hmmm... Why Pesho works here?");
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
