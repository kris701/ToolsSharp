using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using Microsoft.Kiota.Abstractions.Authentication;

namespace ToolsSharp.Services
{
	/// <summary>
	/// A simple service to send out emails
	/// </summary>
	public class SimpleEmailService
	{
		internal readonly string _fromEmail = "";
		internal readonly Guid _clientId = Guid.Empty;
		internal readonly string _clientSecret = "";
		internal readonly Guid _tenantId = Guid.Empty;

		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="fromEmail"></param>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		/// <param name="tenantId"></param>
		public SimpleEmailService(string fromEmail, Guid clientId, string clientSecret, Guid tenantId)
		{
			_fromEmail = fromEmail;
			_clientId = clientId;
			_clientSecret = clientSecret;
			_tenantId = tenantId;
		}

		/// <summary>
		/// Send a email to a single mail
		/// </summary>
		/// <param name="toEmail"></param>
		/// <param name="title"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public virtual async Task Send(string toEmail, string title, string message) => await Send(new List<string>() { toEmail }, new List<string>(), title, message);

		/// <summary>
		/// Send a email with a given title and message
		/// </summary>
		/// <param name="toEmail"></param>
		/// <param name="ccEmail"></param>
		/// <param name="title"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public virtual async Task Send(List<string> toEmail, List<string> ccEmail, string title, string message)
		{
			try
			{
				var prefix = $"This is an automatic message! Dont respond to it.{Environment.NewLine}{message}";
				var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider(_clientId, _clientSecret, _tenantId));
				var _client = new GraphServiceClient(authenticationProvider);
				var requestBody = new Microsoft.Graph.Users.Item.SendMail.SendMailPostRequestBody
				{
					Message = new Message
					{
						Subject = title,
						Body = new ItemBody
						{
							ContentType = BodyType.Text,
							Content = prefix,
						},
						ToRecipients = toEmail.Select(x => EmailToRecipient(x)).ToList(),
						CcRecipients = ccEmail.Select(x => EmailToRecipient(x)).ToList(),
					},
					SaveToSentItems = false,
				};
				await _client.Users[_fromEmail].SendMail.PostAsync(requestBody);
			}
			catch (Exception ex)
			{
				// accept error
			}
		}

		internal Recipient EmailToRecipient(string email) => new Recipient() { EmailAddress = new EmailAddress() { Address = email } };
	}
}
