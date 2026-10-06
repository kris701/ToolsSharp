namespace ToolsSharp.Services
{
	/// <summary>
	/// Modified <seealso cref="SimpleEmailService"/> for sending to a single email every time
	/// </summary>
	public class ErrorEmailService : SimpleEmailService
	{
		private readonly string _toEmail = "";

		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="fromEmail"></param>
		/// <param name="toEmail"></param>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		/// <param name="tenantId"></param>
		public ErrorEmailService(string fromEmail, string toEmail, string clientId, string clientSecret, string tenantId) : base(fromEmail, clientId, clientSecret, tenantId)
		{
			_toEmail = toEmail;
		}

		/// <summary>
		/// Send email
		/// </summary>
		/// <param name="title"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public async Task Send(string title, string message) => await Send(_toEmail, title, message);
	}
}
