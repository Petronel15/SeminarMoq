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
			//ICarRepository carRepository = new FakeCarRepository();
			//IExcelService excelService = new FakeExcelService();
			//CarsManager sut = new CarsManager(carRepository, excelService);
			Mock<ICarRepository> mockCarRepository = new Mock<ICarRepository>();
			Mock<IExcelService> mockExcelService = new Mock<IExcelService>();
			CarsManager sut = new CarsManager(mockCarRepository.Object, mockExcelService.Object);


			//Act
			bool result = sut.Export("fileDemo.csv");
			
			//Assert
			Assert.AreEqual(false,result);
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
