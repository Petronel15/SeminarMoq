using SeminarMoq.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarMoq.TestUnits
{
	internal class FakeExcelService : IExcelService
	{
		public bool Success { get; set; }

		public void Export(string fileName, object cars)
		{
			Success = true;
			//LogTheExport
		}
	}
}
