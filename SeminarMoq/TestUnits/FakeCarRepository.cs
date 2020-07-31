using SeminarMoq.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarMoq.TestUnits
{
	internal class FakeCarRepository : ICarRepository
	{

		List<Car> cars = new List<Car>();

		public FakeCarRepository()
		{
			this.cars = new List<Car>();
		}

		public FakeCarRepository(List<Car> cars)
		{
			this.cars = cars;
		}

		public List<Car> GetAll()
		{
			return this.cars;
		}
	}
}
