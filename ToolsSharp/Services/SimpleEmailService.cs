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
		private readonly string _fromEmail = "";
		private readonly string _clientId = "";
		private readonly string _clientSecret = "";
		private readonly string _tenantId = "";

		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="fromEmail"></param>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		/// <param name="tenantId"></param>
		public SimpleEmailService(string fromEmail, string clientId, string clientSecret, string tenantId)
		{
			_fromEmail = fromEmail;
			_clientId = clientId;
			_clientSecret = clientSecret;
			_tenantId = tenantId;
		}

		/// <summary>
		/// Send a email with a given title and message
		/// </summary>
		/// <param name="toEmail"></param>
		/// <param name="title"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public virtual async Task Send(string toEmail, string title, string message)
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
						ToRecipients = new List<Recipient>() { EmailToRecipient(toEmail) },
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

		private Recipient EmailToRecipient(string email) => new Recipient() { EmailAddress = new EmailAddress() { Address = email } };
	}

	// https://medium.com/@mitchelldalehein25/connecting-to-microsoft-graph-api-with-a-client-secret-c-f791440231f1
	internal class TokenProvider : IAccessTokenProvider
	{
		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly string _tenantId;
		public TokenProvider(string clientId, string clientSecret, string tenantId)
		{
			_clientId = clientId;
			_clientSecret = clientSecret;
			_tenantId = tenantId;
		}
		public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
			CancellationToken cancellationToken = default)
		{
			var app = ConfidentialClientApplicationBuilder.Create(_clientId)
				.WithClientSecret(_clientSecret)
				.WithAuthority(new Uri($"https://login.microsoftonline.com/{_tenantId}"))
				.Build();
			var scopes = new string[] { "https://graph.microsoft.com/.default" };
			var result = app.AcquireTokenForClient(scopes).ExecuteAsync().Result;
			return Task.FromResult(result.AccessToken);
		}
		public AllowedHostsValidator AllowedHostsValidator { get; }
	}
}
