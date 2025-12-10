using System.ComponentModel.DataAnnotations;

namespace ToolsSharp.ComponentModel
{
	/// <summary>
	/// Attribute to set specific <seealso href="https://stackoverflow.com/a/17243820">allowed values of a property.</seealso>
	/// You simply add the attribute to a property and set what values are allowed.
	/// The ComponentModel will then validate that the given value of the property is any one of the values allowed.
	/// </summary>
	public class ValidValuesAttribute : ValidationAttribute
	{
		private readonly string[] _args;

		/// <summary>
		/// Set the allowed values
		/// </summary>
		/// <param name="args"></param>
		public ValidValuesAttribute(params string[] args)
		{
			_args = args;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (_args.Contains((string)value))
				return ValidationResult.Success;
			return new ValidationResult($"Invalid value! Allowed values are: {string.Join(',', _args)}");
		}
	}
}