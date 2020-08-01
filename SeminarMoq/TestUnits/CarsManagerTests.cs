using Moq;
using NUnit.Framework;
using SeminarMoq.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SeminarMoq.TestUnits
{
	[TestFixture]
	public class CarsManagerTests
	{

		[Test]
		public void ShouldNotExportForNoCars()
		{
			//Arrange
			Mock<ICarRepository> mockCarRepository = new Mock<ICarRepository>();
			mockCarRepository.Setup(p => p.GetAll()).Returns(new List<Car>());
			var carRepo = mockCarRepository.Object;
			
			Mock<IExcelService> mockExcelService = new Mock<IExcelService>();
			mockExcelService.Setup(p => p.Export("fileDemo.csv", mockCarRepository.Object));
			mockExcelService.SetupGet(p => p.Success).Returns(false);
			var excelService = mockExcelService.Object;

			//Act
			carRepo.GetAll();
			excelService.Export("fileDemo.csv", mockCarRepository.Object);

			//Assert
			mockCarRepository.Verify();
			mockExcelService.Verify();
		}


		[Test]
		public void ShouldExportForExistingCars()
		{
			//Arrange
			//ICarRepository carRepository = new FakeCarRepository(new List<Car>() { new Car() });
			//IExcelService excelService = new FakeExcelService();
			//CarsManager sut = new CarsManager(carRepository, excelService);
			Mock<CarRepository> mockCarRepository = new Mock<CarRepository>();
			Mock<ExcelService> mockExcelService = new Mock<ExcelService>();
			CarsManager sut = new CarsManager(mockCarRepository.Object, mockExcelService.Object);
			//Act
			bool result = sut.Export("fileDemo.csv");

			//Assert
			Assert.AreEqual(true, result);
		}

	}
}
