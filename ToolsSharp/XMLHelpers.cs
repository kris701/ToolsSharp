using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ToolsSharp
{
	public static class XMLHelpers
	{
		public static XElement? GetElementByPath(this XElement parent, string path, string nameSpace = "")
		{
			XNamespace ns = nameSpace;

			var split = path.Split('.', StringSplitOptions.RemoveEmptyEntries);
			var current = parent;
			foreach (var item in split)
			{
				current = current.Element(ns + item);
				if (current == null)
					return null;
			}
			return current;
		}
	}
}
