using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarMoq.Production
{
	public interface IExcelService
	{
		bool Success { get; }

		void Export(string fileName, object cars);
	}
}
