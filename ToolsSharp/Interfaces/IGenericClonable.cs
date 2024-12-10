using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsSharp.Interfaces
{
	public interface IGenericClonable<T>
	{
		public T Clone();
	}
}
