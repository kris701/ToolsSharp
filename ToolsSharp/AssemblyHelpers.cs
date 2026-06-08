using System.Reflection;

namespace ToolsSharp
{
	/// <summary>
	/// Set of helpers for Assemblies
	/// </summary>
	public static class AssemblyHelpers
	{
		/// <summary>
		/// Gets all types from a given assembly and namespace.
		/// https://stackoverflow.com/a/949285
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="nameSpace"></param>
		/// <returns></returns>
		public static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
		{
			return
				assembly.GetTypes()
						.Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
						.ToArray();
		}
	}
}
