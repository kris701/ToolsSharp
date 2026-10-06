using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Authentication;

namespace ToolsSharp.Services
{
	/// <summary>
	/// Modified <seealso cref="SimpleEmailService"/> for sending to a single email every time
	/// </summary>
	public class FileEmailService : SimpleEmailService
	{
		/// <summary>
		/// Main constructor
		/// </summary>
		/// <param name="fromEmail"></param>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		/// <param name="tenantId"></param>
		public FileEmailService(string fromEmail, string clientId, string clientSecret, string tenantId) : base(fromEmail, clientId, clientSecret, tenantId)
		{
		}

		/// <summary>
		/// Send a email with a given title and message
		/// </summary>
		/// <param name="toEmail"></param>
		/// <param name="ccEmail"></param>
		/// <param name="title"></param>
		/// <param name="message"></param>
		/// <param name="files"></param>
		/// <returns></returns>
		public async Task SendWithFile(List<string> toEmail, List<string> ccEmail, string title, string message, List<FileEmailModel> files)
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
						Attachments = new List<Attachment>(files.Select(x =>
						{
							return new FileAttachment()
							{
								OdataType = "#microsoft.graph.fileAttachment",
								ContentBytes = x.Content,
								Name = x.Name
							};
						}).ToList()),
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

		/// <summary>
		/// Simple file upload model
		/// </summary>
		public class FileEmailModel
		{
			/// <summary>
			/// Name of the file
			/// </summary>
			public string Name { get; set; }
			/// <summary>
			/// Content of the file
			/// </summary>
			public byte[] Content { get; set; }

			/// <summary>
			/// Main constructor
			/// </summary>
			/// <param name="name"></param>
			/// <param name="content"></param>
			public FileEmailModel(string name, byte[] content)
			{
				Name = name;
				Content = content;
			}
		}
	}
}
