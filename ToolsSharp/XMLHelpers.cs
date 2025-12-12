using System.Globalization;
using System.Xml.Linq;

namespace ToolsSharp
{
	public static class XMLHelpers
	{
		public static XElement? GetElementByPath(this XElement parent, string path, XNamespace nameSpace) => parent.GetElementByPath(path, nameSpace.NamespaceName);

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

		public static decimal? GetDecimalValue(this XElement xElement)
		{
			return decimal.Parse(xElement.Value, new CultureInfo("en-US"));
		}

		public static int? GetIntValue(this XElement xElement)
		{
			return int.Parse(xElement.Value);
		}

		public static DateTime? GetDateTimeValue(this XElement xElement)
		{
			return DateTime.Parse(xElement.Value);
		}
	}
}
