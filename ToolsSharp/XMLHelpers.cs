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

		public static XElement? GetFirstDescendantOrDefault(this XElement parent, string name)
		{
			return parent.DescendantsAndSelf().FirstOrDefault(x => x.Name.LocalName == name);
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

		public static string ConvertXDocumentToString(XDocument doc)
		{
			if (doc.Root == null)
				throw new ArgumentNullException("Root element is missing from the XDocument!");
			return ConvertXElementToString(doc.Root);
		}

		public static string ConvertXElementToString(XElement element)
		{
			string result;

			// Set the declaration for the document to indicate that it's using UTF-8 encoding.
			if (element.Document != null)
				element.Document.Declaration = new XDeclaration("1.0", "utf-8", null);

			// Save the XElement to a StringWriter and get the resulting string.
			using (var writer = new StringWriter())
			{
				element.Save(writer);
				result = writer.ToString();
			}

			// Replace the declaration, which is set to UTF-16 by default, with one that specifies UTF-8 encoding.
			result = result.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>");

			return result;
		}
	}
}
