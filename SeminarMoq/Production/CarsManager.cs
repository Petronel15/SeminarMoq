using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarMoq.Production
{
	internal class CarsManager
	{
		private readonly ICarRepository carRepository;
		private readonly IExcelService excelService;

		public CarsManager(ICarRepository carRepository, IExcelService excelService)
		{
			this.carRepository = carRepository;
			this.excelService = excelService;
		}


		internal bool Export(string fileName)
		{
			List<Car> cars = carRepository.GetAll();
			if (cars==null)
            {
				cars = new List<Car>();
            }
			//cars = (cars == null) ? new List<Car>() : cars;

			if (cars.Count >0)
			{
				excelService.Export(fileName, cars);
				if (excelService.Success)
					return true;
			}
			
			return false;
		}
	}
}
